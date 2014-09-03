namespace VineSharp.Responses
{
    public abstract class VineResponse<TData>
    {
        public string Code { get; set; }

        public bool Success { get; set; }

        public string Error { get; set; }

        public TData Data { get; set; }
    }
}
