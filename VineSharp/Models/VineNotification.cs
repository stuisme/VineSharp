using System;

namespace VineSharp.Models
{
    public class VineNotification : VineUserObject
    {
        public string Body { get; set; }
        public long DisplayUserId { get; set; }
        public string ThumbnailUrl { get; set; }
        public bool Verified { get; set; }
        public int NotificationTypeId { get; set; }

        public DateTime Created { get; set; }

        public string DisplayAvatarUrl { get; set; }

        public long NotificationId { get; set; }

        public long Post { get; set; }
    }
}
