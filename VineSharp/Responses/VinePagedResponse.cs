using VineSharp.Models;

namespace VineSharp.Responses
{
    public class VinePagedResponse<TEntity> : VineResponse<PagedWrapper<TEntity>>
    {
    }
}
