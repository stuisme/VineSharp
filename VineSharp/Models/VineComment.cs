using System;

namespace VineSharp.Models
{
    public class VineComment : VineUserTrackedObject
    {
        public long CommentId { get; set; }

        public string Comment { get; set; }
    }
}
