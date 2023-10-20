namespace Satori.Protocol.Elements;

/// <summary>
/// 删除线
/// </summary>
public class DeleteElement : Element
{
    public override string TagName => "s";

    public override string[] AlternativeTagNames => new[] { "del" };
}