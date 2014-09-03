using System.Collections.Generic;

namespace VineSharp.Models
{
    public class VineFollower : VineUserObject
    {
        public bool Verified { get; set; }

        public List<string> VanityUrls { get; set; }

        public bool FollowRequested { get; set; }

        public string Location { get; set; }

        public string ProfileBackground { get; set; }

        public long FollowId { get; set; }

        public VineUserData User { get; set; }

        public bool Following { get; set; }

        public bool Blocked { get; set; }
    }
}
