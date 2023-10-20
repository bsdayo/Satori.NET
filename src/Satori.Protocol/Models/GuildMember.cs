namespace Satori.Protocol.Models;

/// <summary>
/// 群组成员
/// </summary>
public class GuildMember
{
    /// <summary>
    /// 用户对象
    /// </summary>
    public User? User { get; set; }

    /// <summary>
    /// 用户在群组中的名称
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// 用户在群组中的头像
    /// </summary>
    public string? Avatar { get; set; }

    /// <summary>
    /// 加入时间
    /// </summary>
    public long JoinedAt { get; set; }
}