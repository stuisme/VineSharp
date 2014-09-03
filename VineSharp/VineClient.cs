using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using PortableRest;
using VineSharp.Constants;
using VineSharp.Converters;
using VineSharp.Exceptions;
using VineSharp.Models;
using VineSharp.Requests;
using VineSharp.Responses;

namespace VineSharp
{
    public class VineClient
    {
        private string _username;
        private string _password;
        private VineAuthentication _authenticatedUser = null;

        /// <summary>
        /// Creates a new instance of a VineClient. If using this constructor, you must use SetCredentials before calling api methods that require auth.
        /// </summary>
        public VineClient()
        {
            
        }

        /// <summary>
        /// Creates a new instance of a VineClient with default credentials.
        /// </summary>
        public VineClient(string username, string password)
        {
            _username = username;
            _password = password;
        }

        /// <summary>
        /// Set the username and password for the client to obtain a vine sessionId. 
        /// If this is called after the client has authenticated, it will reset authentication
        /// </summary>
        /// <param name="username">username to authenticate with</param>
        /// <param name="password">password for the user</param>
        public void SetCredentials(string username, string password)
        {
            _username = username;
            _password = password;

            _authenticatedUser = null;
        }

        /// <summary>
        /// Authenicates the vine client. This will be called automatically if the client has not authenticated already and the endpoint requires authentication.
        /// </summary>
        /// <returns>The response from vine</returns>
        public async Task<VineAuthenticationResponse> Authenticate()
        {
            var request = GetBaseRequest(VineEndpoints.Authenticate, HttpMethod.Post, ContentTypes.FormUrlEncoded);
            request.AddParameter("username", _username);
            request.AddParameter("password", _password);

            var result = await GetReuslt<VineAuthenticationResponse>(request, false);
            _authenticatedUser = result.Data;

            return result;
        }

        public async Task<VineProfileResponse> MyProfile()
        {
            var request = GetBaseRequest(VineEndpoints.UsersMe);

            return await GetReuslt<VineProfileResponse>(request);
        }

        public async Task<VineProfileResponse> Profile(long userId)
        {
            var request = GetBaseRequest(VineEndpoints.UserProfile);
            request.AddUrlSegment("userId", userId.ToString(CultureInfo.InvariantCulture));

            return await GetReuslt<VineProfileResponse>(request);
        }

        public async Task<VineFollowersResponse> MyFollowers()
        {
            return await UserFollowers(_authenticatedUser.UserId);
        }

        public async Task<VineFollowersResponse> UserFollowers(long userId)
        {
            var request = GetBaseRequest(VineEndpoints.UserFollowers);
            request.AddUrlSegment("userId", userId.ToString(CultureInfo.InvariantCulture));

            return await GetReuslt<VineFollowersResponse>(request);
        }

        public async Task<VineTimelineResponse> MyTimeline(VinePagingOptions options = null)
        {
            return await UserTimeline(_authenticatedUser.UserId, options);
        }

        public async Task<VineTimelineResponse> UserTimeline(long userId, VinePagingOptions options = null)
        {
            var request = GetBaseRequest(VineEndpoints.TimelineUser);
            request.AddUrlSegment("userId", userId.ToString(CultureInfo.InvariantCulture));

            AddPagingOptions(request, options);

            return await GetReuslt<VineTimelineResponse>(request);
        }

        public async Task<VineTimelineResponse> PopularTimeline()
        {
            var request = GetBaseRequest(VineEndpoints.TimelinesPopular);

            return await GetReuslt<VineTimelineResponse>(request);
        }

        public async Task<VineTimelineResponse> TagTimeline(string tag, VinePagingOptions options = null)
        {
            var request = GetBaseRequest(VineEndpoints.TimelineTag);
            request.AddUrlSegment("tag", tag);

            AddPagingOptions(request, options);

            return await GetReuslt<VineTimelineResponse>(request);
        }

        public async Task<VineTimelineResponse> Post(long postId)
        {
            var request = GetBaseRequest(VineEndpoints.SinglePost);
            request.AddUrlSegment("postId", postId.ToString(CultureInfo.InvariantCulture));

            return await GetReuslt<VineTimelineResponse>(request);
        }

        public async Task<VineLikesResponse> Likes(long postId, VinePagingOptions options = null)
        {
            var request = GetBaseRequest(VineEndpoints.PostLikes);
            request.AddUrlSegment("postId", postId.ToString(CultureInfo.InvariantCulture));

            AddPagingOptions(request, options);

            return await GetReuslt<VineLikesResponse>(request);
        }

        public async Task<VineCommentsResponse> Comments(long postId, VinePagingOptions options = null)
        {
            var request = GetBaseRequest(VineEndpoints.PostComments);
            request.AddUrlSegment("postId", postId.ToString(CultureInfo.InvariantCulture));

            AddPagingOptions(request, options);

            return await GetReuslt<VineCommentsResponse>(request);
        }

        #region Helpers
        private static RestRequest GetBaseRequest(string endpoint, HttpMethod method = null, ContentTypes contentType = ContentTypes.Json)
        {
            method = method ?? HttpMethod.Get;
            var request = new RestRequest(endpoint, method, contentType);
            // looks like portable rest controls the default user agent, this forces it for the request
            request.AddHeader("user-agent", "com.vine.iphone/1.0.3 (unknown, iPhone OS 6.0.1, iPhone, Scale/2.000000)");
            
            return request;
        }

        private void AddPagingOptions(RestRequest request, VinePagingOptions options)
        {
            if (options == null)
                return;

            if (options.Size != default(int))
                request.AddQueryString("size", options.Size);
        }

        private async Task<T> GetReuslt<T>(RestRequest request, bool requireAuth = true) where T : class
        {
            var client = await GetClient(requireAuth);
            var response = await client.SendAsync<T>(request);

            if (response.Exception != null || !response.HttpResponseMessage.IsSuccessStatusCode)
                throw GetResponseException<T>(response);

            return response.Content;
        }

        private Exception GetResponseException<T>(RestResponse<T> response) where T : class 
        {
            if (response.Exception != null)
                return response.Exception;

            return new VineSharpRestException<T>(response);

        }

        private async Task<RestClient> GetClient(bool requireAuth = true)
        {
            var client = new RestClient
            {
                JsonSerializerSettings = GetSettings(),
                BaseUrl = VineEndpoints.BaseUrl
            };

            client.AddHeader("accept-language", "en, sv, fr, de, ja, nl, it, es, pt, pt-PT, da, fi, nb, ko, zh-Hans, zh-Hant, ru, pl, tr, uk, ar, hr, cs, el, he, ro, sk, th, id, ms, en-GB, ca, hu, vi, en-us;q=0.8");
            
            if (requireAuth && (string.IsNullOrWhiteSpace(_username) || string.IsNullOrWhiteSpace(_password)))
                throw new VineSharpConfigurationException();

            if (!requireAuth)
                return client;

            // authenticate and add headers
            if (_authenticatedUser == null)
            {
                await Authenticate();
            }

            client.AddHeader("vine-session-id", _authenticatedUser.Key);

            return client;
        }

        private static JsonSerializerSettings GetSettings()
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Converters = new JsonConverter[] { new IsoDateTimeConverter(), new BoolConverter() }
            };
            return settings;
        }
        #endregion
    }
}
