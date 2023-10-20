namespace Satori.Protocol.Elements;

/// <summary>
/// 作者
/// </summary>
public class AuthorElement : Element
{
    public override string TagName => "author";

    /// <summary>
    /// 用户 ID
    /// </summary>
    public string? UserId { get; set; }

    /// <summary>
    /// 昵称
    /// </summary>
    public string? Nickname { get; set; }

    /// <summary>
    /// 头像 URL
    /// </summary>
    public string? Avatar { get; set; }
}