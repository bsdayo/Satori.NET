namespace Satori.Protocol.Events;

public class IdentifySignalBody
{
    /// <summary>
    /// 鉴权令牌
    /// </summary>
    public string? Token { get; set; }

    /// <summary>
    /// 序列号
    /// </summary>
    public string? Sequence { get; set; }
}