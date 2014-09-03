using System.Collections.Generic;

namespace VineSharp.Models
{
    public class VineProfile : VineUserObject
    {
        // TODO: implement property from json
        //    "statsTags": { "e12": "1" },
        public int FollowerCount { get; set; }

        public bool IncludePromoted { get; set; }
        public bool HiddenPhoneNumber { get; set; }
        public bool Private { get; set; }

        public bool HiddenEmail { get; set; }

        public string Edition { get; set; }

        public int PostCount { get; set; }

        public bool VerifiedEmail { get; set; }
        public bool ExplicitContent { get; set; }
        public bool Blocked { get; set; }
        public bool Verified { get; set; }

        public int LoopCount { get; set; }

        public int AuthoredPostCount { get; set; }

        public string Description { get; set; }

        public int Blocking { get; set; }
        public string PhoneNumber { get; set; }
        public string Location { get; set; }

        public bool NotifyActivity { get; set; }

        public bool FacebookConnected { get; set; }

        public string Email { get; set; }

        public List<string> VanityUrls { get; set; }

        public bool Following { get; set; }

        public bool TwitterConnected { get; set; }

        public bool VerifiedPhoneNumber { get; set; }

        public bool HiddenTwitter { get; set; }

        public int LikeCount { get; set; }

        public bool NotifyMessages { get; set; }

        public string TwitterScreenname { get; set; }
        public long? TwitterId { get; set; }

        public bool AcceptsOutOfNetworkConversations { get; set; }

        public bool DisableAddressBook { get; set; }

        public string ShareUrl { get; set; }

        public bool NotifyPosts { get; set; }

        public int FollowingCount { get; set; }

        public bool RepostsEnabled { get; set; }
    }
}
