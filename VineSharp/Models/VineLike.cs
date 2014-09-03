using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace VineSharp.Models
{
    /// <summary>
    /// Object to represent a user like
    /// </summary>
    public class VineLike : VineUserTrackedObject
    {
        /// <summary>
        /// The like unique identifier
        /// </summary>
        public long LikeId { get; set; }
        public long PostId { get; set; }

        public string VideoUrl { get; set; }

        public string VideoDashUrl { get; set; }

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
    }
}
