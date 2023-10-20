namespace Satori.Protocol.Models;

/// <summary>
/// 消息
/// </summary>
public class Message
{
    /// <summary>
    /// 消息 ID
    /// </summary>
    public string Id { get; set; } = "";

    /// <summary>
    /// 消息内容
    /// </summary>
    public string Content { get; set; } = "";

    /// <summary>
    /// 频道对象
    /// </summary>
    public Channel? Channel { get; set; }

    /// <summary>
    /// 群组对象
    /// </summary>
    public Guild? Guild { get; set; }

    /// <summary>
    /// 成员对象
    /// </summary>
    public GuildMember? Member { get; set; }

    /// <summary>
    /// 用户对象
    /// </summary>
    public User? User { get; set; }

    /// <summary>
    /// 消息发送的时间戳
    /// </summary>
    public long CreatedAt { get; set; }

    /// <summary>
    /// 消息修改的时间戳
    /// </summary>
    public long UpdatedAt { get; set; }
}