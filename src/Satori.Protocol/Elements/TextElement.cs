namespace Satori.Protocol.Elements;

/// <summary>
/// 纯文本
/// </summary>
public class TextElement : Element
{
    public override string TagName => "";

    /// <summary>
    /// 文本
    /// </summary>
    public string Text { get; set; } = "";
}