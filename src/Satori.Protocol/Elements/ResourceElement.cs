namespace Satori.Protocol.Elements;

public abstract class ResourceElement : Element
{
    /// <summary>
    /// 资源的 URL
    /// </summary>
    public string Src { get; set; } = "";

    /// <summary>
    /// 是否使用已缓存的文件
    /// </summary>
    public bool? Cache { get; set; }

    /// <summary>
    /// 下载文件的最长时间 (毫秒)
    /// </summary>
    public string? Timeout { get; set; }
}