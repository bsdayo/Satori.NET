using System.ComponentModel;
using HtmlAgilityPack;

namespace Satori.Protocol.Elements;

public static partial class ElementSerializer
{
    private static readonly Type[] BuiltinElementTypes =
    {
        // 基础元素
        typeof(TextElement), typeof(AtElement), typeof(SharpElement), typeof(LinkElement),
        // 资源元素
        typeof(ImageElement), typeof(AudioElement), typeof(VideoElement), typeof(FileElement),
        // 修饰元素
        typeof(BoldElement), typeof(ItalicElement), typeof(UnderlineElement), typeof(DeleteElement),
        typeof(SpoilerElement), typeof(CodeElement), typeof(SuperscriptElement), typeof(SubscriptElement),
        // 排版元素
        typeof(BreakElement), typeof(ParagraphElement), typeof(MessageElement),
        // 元信息元素
        typeof(QuoteElement), typeof(AuthorElement)
    };

    private static Dictionary<string, Type>? _builtinElementMap;

    private static Dictionary<string, Type> GetBuiltinElementMap()
    {
        var map = new Dictionary<string, Type>();
        foreach (var type in BuiltinElementTypes)
        {
            var element = (Element)Activator.CreateInstance(type)!;

            if (element.TagName is null) continue;
            map[element.TagName] = type;

            if (element.AlternativeTagNames is null) continue;
            foreach (var tag in element.AlternativeTagNames)
                map[tag] = type;
        }

        return map;
    }

    /// <summary>
    /// 递归调用
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="map"></param>
    /// <param name="node"></param>
    private static void AddChildElements(IList<Element> parent, IDictionary<string, Type> map, HtmlNode node)
    {
        Element? element = null;

        switch (node.NodeType)
        {
            // 纯文本直接为 TextElement
            case HtmlNodeType.Text:
                element = new TextElement { Text = node.InnerText };
                break;

            case HtmlNodeType.Element:
                if (map.TryGetValue(node.Name, out var type))
                {
                    element = (Element)Activator.CreateInstance(type)!;
                    foreach (var attr in node.Attributes)
                    {
                        element.Attributes[attr.Name] = attr.Value;
                        var propName = ConvertKebabToPascal(attr.Name);
                        var prop = type.GetProperty(propName);
                        if (prop is null) continue;

                        object? value;
                        // 对于一个 HTML Boolean Attributes，只要出现了就直接设为 true
                        if (prop.PropertyType == typeof(bool?) || prop.PropertyType == typeof(bool))
                            value = true;
                        else
                            value = TypeDescriptor.GetConverter(prop.PropertyType).ConvertFromString(attr.Value);
                        prop.SetValue(element, value);
                    }
                }
                else
                {
                    element = new Element();
                    foreach (var attrObj in node.Attributes)
                    {
                        var attr = (HtmlAttribute)attrObj;
                        element.Attributes[attr.Name] = attr.Value;
                    }
                }

                foreach (var childNode in node.ChildNodes)
                    AddChildElements(element.ChildElements, map, childNode);

                break;
        }

        if (element is not null)
            parent.Add(element);
    }

    public static IEnumerable<Element> Deserialize(string content, IDictionary<string, Type>? externalElementMap = null)
    {
        _builtinElementMap ??= GetBuiltinElementMap();

        var map = externalElementMap is not null
            ? new Dictionary<string, Type>(_builtinElementMap.Concat(externalElementMap))
            : _builtinElementMap;

        var document = new HtmlDocument();
        document.LoadHtml(content);

        var list = new List<Element>();

        foreach (var htmlNode in document.DocumentNode.ChildNodes) AddChildElements(list, map, htmlNode);

        return list;
    }
}