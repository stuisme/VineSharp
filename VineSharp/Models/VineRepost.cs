using System;

namespace VineSharp.Models
{
    /// <summary>
    /// Represents the object returned when a user reposts
    /// </summary>
    public class VineRepost
    {
        /// <summary>
        /// Repost Id as a string
        /// </summary>
        public string RepostIdStr { get; set; }

        /// <summary>
        /// Unique post id for the repost
        /// </summary>
        public long RepostId { get; set; }

        /// <summary>
        /// Post Id as a string
        /// </summary>
        public string PostIdStr { get; set; }

        /// <summary>
        /// Post Id that was reposted
        /// </summary>
        public long PostId { get; set; }

        /// <summary>
        /// DateTime for when the repost was created
        /// </summary>
        public DateTime Created { get; set; }
    }
}
