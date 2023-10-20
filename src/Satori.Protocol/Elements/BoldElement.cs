namespace Satori.Protocol.Elements;

/// <summary>
/// 粗体
/// </summary>
public class BoldElement : Element
{
    public override string TagName => "b";

    public override string[] AlternativeTagNames => new[] { "strong" };
}