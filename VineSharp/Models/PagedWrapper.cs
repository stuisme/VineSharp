using System.Collections.Generic;

namespace VineSharp.Models
{
    /// <summary>
    /// Standard Paged wrapper for vine collections
    /// </summary>
    /// <typeparam name="TList">Type of the Records collection</typeparam>
    public class PagedWrapper <TList>
    {
        /// <summary>
        /// The total number of records in the collection
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// The current page size
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// String version of Anchor
        /// </summary>
        public string AnchorStr { get; set; }

        /// <summary>
        /// Anchor string to traverse the collection
        /// </summary>
        public string BackAnchor { get; set; }

        /// <summary>
        /// Numerical representation of the Anchor to hold paging
        /// </summary>
        public long? Anchor { get; set; }

        /// <summary>
        /// Previous page parameter to use to move backwards in the collection
        /// </summary>
        public string PreviousPage { get; set; }

        /// <summary>
        /// Next page parameter to use to move forward in the collection
        /// </summary>
        public string NextPage { get; set; }

        /// <summary>
        /// Collection of the current size
        /// </summary>
        public IEnumerable<TList> Records { get; set; }
    }
}
