using System;
using PortableRest;

namespace VineSharp.Exceptions
{
    internal class VineSharpRestException<T> : Exception where T : class
    {
        public readonly RestResponse<T> Response;
        public VineSharpRestException(RestResponse<T> response)
            : base(string.Format("The url {0} returned ({1} - {2})",
                response.HttpResponseMessage.RequestMessage.RequestUri,
                response.HttpResponseMessage.StatusCode,
                response.HttpResponseMessage.ReasonPhrase
                ))
        {
            Response = response;
        }
    }
}
