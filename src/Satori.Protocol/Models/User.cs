namespace Satori.Protocol.Models;

/// <summary>
/// 用户
/// </summary>
public class User
{
    /// <summary>
    /// 群组 ID
    /// </summary>
    public string Id { get; set; } = "";

    /// <summary>
    /// 群组名称
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// 群组头像
    /// </summary>
    public string? Avatar { get; set; }

    /// <summary>
    /// 是否为机器人
    /// </summary>
    public bool IsBot { get; set; }
}