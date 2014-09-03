using System.Collections.Generic;

namespace VineSharp.Models
{
    public class PagedWrapper <TList>
    {
        public int Count { get; set; }
        public int Size { get; set; }
        public string AnchorStr { get; set; }
        public string BackAnchor { get; set; }
        public long? Anchor { get; set; }
        public string PreviousPage { get; set; }
        public string NextPage { get; set; }

        public IEnumerable<TList> Records { get; set; }
    }
}
