namespace VineSharp.Models
{
    public class VineAuthentication : VineUserObject
    {
        /// <summary>
        /// Represents the language of this api
        /// </summary>
        public string Edition { get; set; }

        /// <summary>
        /// This key is used for all authenticated requests to represent the user
        /// </summary>
        public string Key { get; set; }
    }
}
