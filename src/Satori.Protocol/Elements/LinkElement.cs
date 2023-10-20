namespace Satori.Protocol.Elements;

/// <summary>
/// 链接
/// </summary>
public class LinkElement : Element
{
    public override string TagName => "a";

    public string Href { get; set; } = "";
}