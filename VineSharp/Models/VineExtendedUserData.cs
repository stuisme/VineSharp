using System.Collections.Generic;

namespace VineSharp.Models
{
    public class VineExtendedUserData : VineUserObject
    {
        public string VideoUrl { get; set; }

        public List<string> VanityUrls { get; set; }

        public string Description { get; set; }

        public string ProfileBackground { get; set; }

        public bool Private { get; set; }

        public bool Verified { get; set; }

        public string VideoDashUrl { get; set; }

        public string Location { get; set; }
    }
}