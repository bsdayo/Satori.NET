using Satori.Protocol.Models;

namespace Satori.Protocol.Events;

public class Event
{
    /// <summary>
    /// 事件 ID
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// 事件类型
    /// </summary>
    public string Type { get; set; } = "";

    /// <summary>
    /// 接收者的平台名称
    /// </summary>
    public string Platform { get; set; } = "";

    /// <summary>
    /// 接收者的平台账号
    /// </summary>
    public string SelfId { get; set; } = "";

    /// <summary>
    /// 事件的时间戳
    /// </summary>
    public long Timestamp { get; set; }

    /// <summary>
    /// 事件所属的频道
    /// </summary>
    public Channel? Channel { get; set; }

    /// <summary>
    /// 事件所属的群组
    /// </summary>
    public Guild? Guild { get; set; }

    /// <summary>
    /// 事件的登录信息
    /// </summary>
    public Login? Login { get; set; }

    /// <summary>
    /// 事件的目标成员
    /// </summary>
    public GuildMember? Member { get; set; }

    /// <summary>
    /// 事件的消息
    /// </summary>
    public Message? Message { get; set; }

    /// <summary>
    /// 事件的操作者
    /// </summary>
    public User? Operator { get; set; }

    /// <summary>
    /// 事件的目标角色
    /// </summary>
    public GuildRole? Role { get; set; }

    /// <summary>
    /// 事件的目标角色
    /// </summary>
    public User? User { get; set; }
}