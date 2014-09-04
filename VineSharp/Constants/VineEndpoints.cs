namespace VineSharp.Constants
{
    internal static class VineEndpoints
    {
        internal const string BaseUrl = "https://vine.co/api/";

        internal const string Authenticate = "users/authenticate";
        internal const string UsersMe = "users/me";
        internal const string UserProfile = "users/profiles/{userId}";
        internal const string UserFollowers = "users/{userId}/followers";
        internal const string UserFollowing = "users/{userId}/following";

        internal const string TimelineUser = "timelines/users/{userId}";
        internal const string TimelineTag = "timelines/tags/{tag}";
        internal const string SinglePost = "timelines/posts/{postId}";
        internal const string TimelinesPopular = "timelines/popular";

        internal const string PostLikes = "posts/{postId}/likes";
        internal const string PostComments = "posts/{postId}/comments";
        
    }
}
