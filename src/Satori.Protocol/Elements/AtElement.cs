namespace Satori.Protocol.Elements;

/// <summary>
/// 提及用户
/// </summary>
public class AtElement : Element
{
    public override string TagName => "at";

    /// <summary>
    /// 目标用户的 ID
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    /// 目标用户的名称
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// 目标角色
    /// </summary>
    public string? Role { get; set; }

    /// <summary>
    /// 特殊操作，例如 all 表示 @全体成员，here 表示 @在线成员
    /// </summary>
    public string? Type { get; set; }
}