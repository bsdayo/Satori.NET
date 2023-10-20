namespace Satori.Protocol.Elements;

public class Element
{
    public virtual string? TagName => null;

    public virtual string[]? AlternativeTagNames { get; } = null;

    public IList<Element> ChildElements { get; } = new List<Element>();

    public IDictionary<string, string> Attributes { get; } = new Dictionary<string, string>();
}