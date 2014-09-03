namespace VineSharp.Constants
{
    public static class VineEndpoints
    {
        public const string BaseUrl = "https://api.vineapp.com/";
         
        public const string Authenticate = "users/authenticate";

        public const string UsersMe = "users/me";
        public const string UserProfile = "users/profiles/{userId}";
        public const string TimelinesMe = "timelines/me";
        public const string TimelineUser = "timelines/users/{userId}";
        public const string TimelineTag = "timelines/tags/{tag}";
        public const string SinglePost = "posts/{postId}";
    }
}
