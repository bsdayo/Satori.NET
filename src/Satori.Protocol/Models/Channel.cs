namespace Satori.Protocol.Models;

/// <summary>
/// 频道
/// </summary>
public class Channel
{
    /// <summary>
    /// 频道 ID
    /// </summary>
    public string Id { get; set; } = "";

    /// <summary>
    /// 频道类型
    /// </summary>
    public ChannelType Type { get; set; }

    /// <summary>
    /// 频道名称
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// 父频道 ID
    /// </summary>
    public string? ParentId { get; set; }
}

public enum ChannelType
{
    /// <summary>
    /// 文本频道
    /// </summary>
    Text = 1,

    /// <summary>
    /// 语音频道
    /// </summary>
    Voice = 2,

    /// <summary>
    /// 分类频道
    /// </summary>
    Category = 3,

    /// <summary>
    /// 私聊频道
    /// </summary>
    Direct = 4
}