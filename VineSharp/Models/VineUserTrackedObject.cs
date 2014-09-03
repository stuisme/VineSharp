using System;

namespace VineSharp.Models
{
    /// <summary>
    /// Abstract class that contains other properties that are common with objects created by users.
    /// </summary>
    public abstract class VineUserTrackedObject : VineUserObject
    {
        /// <summary>
        /// The date in which this object was posted
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// The location of the user at the time of the post
        /// </summary>
        public string Locale { get; set; }
    }
}
