namespace Satori.Protocol.Elements;

/// <summary>
/// 下划线
/// </summary>
public class UnderlineElement : Element
{
    public override string TagName => "u";

    public override string[] AlternativeTagNames => new[] { "ins" };
}