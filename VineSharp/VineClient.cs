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
    /// <summary>
    /// Class to wrap communication with the Vine api
    /// </summary>
    public class VineClient
    {
        private const string Me = "me";
        private string _username;
        private string _password;
        private VineAuthentication _authenticatedUser;

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

            var result = await GetResult<VineAuthenticationResponse>(request, false);
            
            return result;
        }

        ///////// User Data /////////
        
        /// <summary>
        /// Gets the profile information for the current authenticated user
        /// </summary>
        /// <returns>Standard Response with User Profile data</returns>
        public async Task<VineProfileResponse> MyProfile()
        {
            var request = GetBaseRequest(VineEndpoints.UsersMe);
            
            return await GetResult<VineProfileResponse>(request);
        }

        /// <summary>
        /// Gets the profile information for the supplied userId
        /// </summary>
        /// <param name="userId">Vine UserId</param>
        /// <returns>Standard Response with User Profile data</returns>
        public async Task<VineProfileResponse> UserProfile(long userId)
        {
            var request = GetBaseUserRequest(VineEndpoints.UserProfile, userId.ToString(CultureInfo.InvariantCulture));
            
            return await GetResult<VineProfileResponse>(request);
        }

        /// <summary>
        /// Gets a paged list of people following the authenticated user
        /// </summary>
        /// <param name="options">paging options</param>
        /// <returns>Standard Paged Response of VineFollowers (similar to a VineProfile)</returns>
        public async Task<VineFollowersResponse> MyFollowers(VinePagingOptions options = null)
        {
            var request = GetBaseUserRequest(VineEndpoints.UserFollowing, Me, options);
            
            return await GetResult<VineFollowersResponse>(request);
        }

        /// <summary>
        /// Gets a paged list of people following a specified user
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="options">paging options</param>
        /// <returns>Standard Paged Response of VineFollowers (similar to a VineProfile)</returns>
        public async Task<VineFollowersResponse> UserFollowers(long userId, VinePagingOptions options = null)
        {
            var request = GetBaseUserRequest(VineEndpoints.UserFollowers, userId.ToString(CultureInfo.InvariantCulture), options);
            
            return await GetResult<VineFollowersResponse>(request);
        }

        /// <summary>
        /// Gets a paged list of people the authenticated user is following
        /// </summary>
        /// <param name="options">paging options</param>
        /// <returns>Standard Paged Response of VineFollowers (similar to a VineProfile)</returns>
        public async Task<VineFollowersResponse> MyFollowing(VinePagingOptions options = null)
        {
            var request = GetBaseUserRequest(VineEndpoints.UserFollowers, Me, options);
            
            return await GetResult<VineFollowersResponse>(request);
        }

        /// <summary>
        /// Gets a paged list of people the specified user is following
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="options">paging options</param>
        /// <returns>Standard Paged Response of VineFollowers (similar to a VineProfile)</returns>
        public async Task<VineFollowersResponse> UserFollowing(long userId, VinePagingOptions options = null)
        {
            var request = GetBaseUserRequest(VineEndpoints.UserFollowing, userId.ToString(CultureInfo.InvariantCulture), options);
            
            return await GetResult<VineFollowersResponse>(request);
        }

        ///////// Timelines /////////

        /// <summary>
        /// Gets a paged list of posts in the authenticated user's timeline
        /// </summary>
        /// <param name="options">paging options</param>
        /// <returns>Standard Paged Response of VinePosts</returns>
        public async Task<VineTimelineResponse> MyTimeline(VinePagingOptions options = null)
        {
            var request = GetBaseUserRequest(VineEndpoints.TimelineUser, Me);
            AddPagingOptions(request, options);

            return await GetResult<VineTimelineResponse>(request);
        }

        /// <summary>
        /// Gets a paged list of posts for a specified user's timeline
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="options">paging options</param>
        /// <returns>Standard Paged Response of VinePosts</returns>
        public async Task<VineTimelineResponse> UserTimeline(long userId, VinePagingOptions options = null)
        {
            var request = GetBaseUserRequest(VineEndpoints.TimelineUser, userId.ToString(CultureInfo.InvariantCulture));
            AddPagingOptions(request, options);

            return await GetResult<VineTimelineResponse>(request);
        }

        /// <summary>
        /// Gets a paged list of popular posts
        /// </summary>
        /// <param name="options">paging options</param>
        /// <returns>Standard Paged Response of VinePosts</returns>
        public async Task<VineTimelineResponse> PopularTimeline(VinePagingOptions options = null)
        {
            var request = GetBaseRequest(VineEndpoints.TimelinesPopular);
            AddPagingOptions(request, options);
            return await GetResult<VineTimelineResponse>(request);
        }

        /// <summary>
        /// Gets a paged list of posts with a given hashtag
        /// </summary>
        /// <param name="tag">Hashtag with the # removed (i.e. "#test" should be "test") </param>
        /// <param name="options">paging options</param>
        /// <returns>Standard Paged Response of VinePosts</returns>
        public async Task<VineTimelineResponse> TagTimeline(string tag, VinePagingOptions options = null)
        {
            var request = GetBaseRequest(VineEndpoints.TimelineTag);
            request.AddUrlSegment("tag", tag);
            AddPagingOptions(request, options);

            return await GetResult<VineTimelineResponse>(request);
        }

        ///////// Post details /////////

        /// <summary>
        /// Gets a specific post, it will be wrapped in the standard paging response
        /// </summary>
        /// <param name="postId">Post Id</param>
        /// <returns>Standard Paged Response containing 1 post</returns>
        public async Task<VineTimelineResponse> Post(long postId)
        {
            var request = GetBasePostRequest(VineEndpoints.SinglePost, postId.ToString(CultureInfo.InvariantCulture));

            return await GetResult<VineTimelineResponse>(request);
        }

        /// <summary>
        /// Gets a paged list of likes for a given post
        /// </summary>
        /// <param name="postId">Post Id</param>
        /// <param name="options">paging options</param>
        /// <returns>Standard Paged Response of VineLikes</returns>
        public async Task<VineLikesResponse> Likes(long postId, VinePagingOptions options = null)
        {
            var request = GetBasePostRequest(VineEndpoints.PostLikes, postId.ToString(CultureInfo.InvariantCulture), options);

            return await GetResult<VineLikesResponse>(request);
        }

        /// <summary>
        /// Gets a paged list of comments for a given post
        /// </summary>
        /// <param name="postId">Post Id</param>
        /// <param name="options">paging options</param>
        /// <returns>Standard Paged Response of VineComments</returns>
        public async Task<VineCommentsResponse> Comments(long postId, VinePagingOptions options = null)
        {
            var request = GetBaseRequest(VineEndpoints.PostComments);
            request.AddUrlSegment("postId", postId.ToString(CultureInfo.InvariantCulture));

            AddPagingOptions(request, options);

            return await GetResult<VineCommentsResponse>(request);
        }

        /// <summary>
        /// Likes a post for the authenticated user
        /// </summary>
        /// <param name="postId">postId</param>
        /// <returns>Standard Response of Like Acknowledgement</returns>
        public async Task<VineLikeCreation> AddLike(long postId)
        {
            var request = GetBaseRequest(VineEndpoints.PostLikes, HttpMethod.Post);
            request.AddUrlSegment("postId", postId.ToString(CultureInfo.InvariantCulture));

            return await GetResult<VineLikeCreation>(request);
        }

        /// <summary>
        /// Stops liking a post for the authenticated user
        /// </summary>
        /// <param name="postId">Post Id</param>
        /// <returns></returns>
        public async Task<VineEmptyDataResponse> RemovedLike(long postId)
        {
            var request = GetBaseRequest(VineEndpoints.PostLikes, HttpMethod.Delete);
            request.AddUrlSegment("postId", postId.ToString(CultureInfo.InvariantCulture));

            return await GetResult<VineEmptyDataResponse>(request);
        }

        #region Helpers
        private static RestRequest GetBaseRequest(string endpoint, HttpMethod method = null, ContentTypes contentType = ContentTypes.Json)
        {
            method = method ?? HttpMethod.Get;
            var request = new RestRequest(endpoint, method, contentType);
            // looks like portable rest controls the default user agent, this forces it for the request
            request.AddHeader("user-agent", "com.vine.iphone/1.0.3 (unknown, iPhone OS 7.0.0, iPhone, Scale/2.000000)");
            
            return request;
        }

        private static RestRequest GetBaseUserRequest(string endpoint, string userId, VinePagingOptions options = null)
        {
            var request = GetBaseRequest(endpoint);
            request.AddUrlSegment("userId", userId);

            AddPagingOptions(request, options);

            return request;
        }

        private static RestRequest GetBasePostRequest(string endpoint, string postId, VinePagingOptions options = null)
        {
            var request = GetBaseRequest(endpoint);
            request.AddUrlSegment("postId", postId);
            AddPagingOptions(request, options);

            return request;
        }

        private static void AddPagingOptions(RestRequest request, VinePagingOptions options)
        {
            if (options == null)
                return;

            if (options.Size != default(int))
                request.AddQueryString("size", options.Size);

            if (options.Page != default(int))
                request.AddQueryString("size", options.Page);

            if (options.Anchor != default(long))
                request.AddQueryString("anchor", options.Anchor);
        }

        private async Task<T> GetResult<T>(RestRequest request, bool requireAuth = true) where T : class
        {
            var client = await GetClient(requireAuth);
            var response = await client.SendAsync<T>(request);

            if (response.Exception != null || !response.HttpResponseMessage.IsSuccessStatusCode)
                throw GetResponseException(response);

            return response.Content;
        }

        private static Exception GetResponseException<T>(RestResponse<T> response) where T : class
        {
            return response.Exception ?? new VineSharpRestException<T>(response);
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
                // Authenticate sets the _authenticatedUser property
                var authResult = await Authenticate();
                // set the current authenticated user
                _authenticatedUser = authResult.Data;
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
