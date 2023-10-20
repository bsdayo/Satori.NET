namespace Satori.Protocol.Models;

public class DataPagination<T>
{
    /// <summary>
    /// 数据
    /// </summary>
    public IEnumerable<T> Array { get; set; } = System.Array.Empty<T>();

    /// <summary>
    /// 下一页的令牌。可以使用 next 令牌来获取下一页的数据。如果 next 为空，则表示没有更多数据了。
    /// </summary>
    public string? Next { get; set; }
}