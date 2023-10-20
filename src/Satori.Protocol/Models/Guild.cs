namespace Satori.Protocol.Models;

/// <summary>
/// 群组
/// </summary>
public class Guild
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
}