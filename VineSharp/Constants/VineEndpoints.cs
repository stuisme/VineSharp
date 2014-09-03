namespace VineSharp.Constants
{
    public static class VineEndpoints
    {
        public const string BaseUrl = "https://api.vineapp.com/";
         
        public const string Authenticate = "users/authenticate";
        public const string UsersMe = "users/me";
        public const string UserProfile = "users/profiles/{userId}";
        public const string UserFollowers = "users/{userId}/followers";

        public const string TimelineUser = "timelines/users/{userId}";
        public const string TimelineTag = "timelines/tags/{tag}";
        public const string SinglePost = "timelines/posts/{postId}";
        public const string TimelinesPopular = "timelines/popular";

        public const string PostLikes = "posts/{postId}/likes";
        public const string PostComments = "posts/{postId}/comments";
    }
}
