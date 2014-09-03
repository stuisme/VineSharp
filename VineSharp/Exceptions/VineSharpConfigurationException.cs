using System;

namespace VineSharp.Exceptions
{
    /// <summary>
    /// Exception used when the VineClient is not configured
    /// </summary>
    public class VineSharpConfigurationException : Exception
    {
        /// <summary>
        /// Contructor provides message
        /// </summary>
        public VineSharpConfigurationException()
            :base("Please configure your Vine username and password before calling the VineApi")
        {
        }
    }
}
