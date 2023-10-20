namespace Satori.Protocol.Elements;

/// <summary>
/// 斜体
/// </summary>
public class ItalicElement : Element
{
    public override string TagName => "i";

    public override string[] AlternativeTagNames => new[] { "em" };
}