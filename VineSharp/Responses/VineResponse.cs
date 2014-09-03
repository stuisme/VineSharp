namespace VineSharp.Responses
{
    /// <summary>
    /// Standard wrapper for all vine api responses
    /// </summary>
    /// <typeparam name="TData">Type of data in the response</typeparam>
    public abstract class VineResponse<TData>
    {
        /// <summary>
        /// Code for the response typically is an empty string on success
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Flag indicating if the requested action was successful
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Error message if the response was not successful
        /// </summary>
        public string Error { get; set; }

        /// <summary>
        /// Generic data holding the result of the response
        /// </summary>
        public TData Data { get; set; }
    }
}
