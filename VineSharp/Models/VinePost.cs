using System.Collections.Generic;

namespace VineSharp.Models
{
    public class VinePost : VineUserTrackedObject
    {
        public long PostId { get; set; }
        public string Description { get; set; }

        public VineLoops Loops { get; set; }

        public string VideoUrl { get; set; }
        public string VideoLowUrl { get; set; }
        public string ThumbnailUrl { get; set; }

        public string PermalinkUrl { get; set; }

        public string ShareUrl { get; set; }

        public bool Liked { get; set; }
        public bool Promoted { get; set; }
        public bool Verified { get; set; }
        public bool ExplicitContent { get; set; }


        public bool PostToTwitter { get; set; }
        public bool PostToFacebook { get; set; }
        public string FoursquareVenueId { get; set; }

        public long MyRepostId { get; set; }

        public List<string> VanityUrls { get; set; }
        public List<VineEntity> Entities { get; set; }
        public PagedWrapper<VineComment> Comments { get; set; }
        public PagedWrapper<VineLike> Likes { get; set; }

        public PagedWrapper<VinePost> Reposts { get; set; } 
    }
}
