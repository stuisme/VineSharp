using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VineSharp.Models
{
    public class VineComment : VineUserTrackedObject
    {
        public long CommentId { get; set; }

        public string Comment { get; set; }

        public bool Verified { get; set; }

        public List<string> VanityUrls { get; set; }

        /// <summary>
        /// WTF are these?
        /// </summary>
        [JsonProperty("flags|platform_lo")]
        public bool PlatformLo { get; set; }

        /// <summary>
        /// WTF are these?
        /// </summary>
        [JsonProperty("flags|platform_hi")]
        public bool PlatformHi { get; set; }

        public DateTime Modified { get; set; }

        public List<VineEntity> Entities { get; set; }

        public string Location { get; set; }

        public long PostId { get; set; }

        public VineExtendedUserData User { get; set; }
    }
}
