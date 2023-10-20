namespace Satori.Protocol.Elements;

/// <summary>
/// 消息
/// </summary>
public class MessageElement : Element
{
    public override string TagName => "message";

    /// <summary>
    /// 消息的 ID
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    /// 是否为转发消息
    /// </summary>
    public bool? Forward { get; set; }
}