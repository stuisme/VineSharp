using System;

namespace VineSharp.Exceptions
{
    public class VineSharpConfigurationException : Exception
    {
        public VineSharpConfigurationException()
            :base("Please configure your Vine username and password before calling the VineApi")
        {
        }
    }
}
