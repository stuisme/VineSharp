namespace VineSharp.Models
{
    /// <summary>
    /// Abstract class to contain the common properties on an object on vine in which a user is associated.
    /// </summary>
    public abstract class VineUserObject
    {
        /// <summary>
        /// Username of the user that this object belongs to
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// UserId of the user that this object belongs to
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// The profile image for the user this object belongs to
        /// </summary>
        public string AvatarUrl { get; set; }
    }
}
