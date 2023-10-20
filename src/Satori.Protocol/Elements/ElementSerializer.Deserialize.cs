using System.ComponentModel;
using System.Xml;

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

    public static IEnumerable<Element> Deserialize(string content, IDictionary<string, Type>? externalElementMap = null)
    {
        _builtinElementMap ??= GetBuiltinElementMap();

        var map = externalElementMap is not null
            ? new Dictionary<string, Type>(_builtinElementMap.Concat(externalElementMap))
            : _builtinElementMap;

        const string wrapperTagName = "satori-message-wrapper";
        var wrapped = $"<{wrapperTagName}>{content}</{wrapperTagName}>";

        var document = new XmlDocument();
        document.Load(wrapped);
        var root = document.ChildNodes[0]!;

        var list = new List<Element>();

        foreach (var xmlNodeObj in root.ChildNodes)
        {
            var xmlNode = (XmlElement)xmlNodeObj!;

            switch (xmlNode.NodeType)
            {
                case XmlNodeType.Text:
                    list.Add(new TextElement { Text = xmlNode.InnerText });
                    break;

                case XmlNodeType.Element:
                    Element element;
                    if (map.TryGetValue(xmlNode.Name, out var type))
                    {
                        element = (Element)Activator.CreateInstance(type)!;
                        foreach (var attrObj in xmlNode.Attributes)
                        {
                            var attr = (XmlAttribute)attrObj;
                            element.Attributes[attr.Name] = attr.Value;
                            var propName = ConvertKebabToPascal(attr.Name);
                            var prop = type.GetProperty(propName);
                            if (prop is null) continue;
                            var value = TypeDescriptor.GetConverter(prop.PropertyType).ConvertFromString(attr.Value);
                            prop.SetValue(element, value);
                        }
                    }
                    else
                    {
                        element = new Element();
                        foreach (var attrObj in xmlNode.Attributes)
                        {
                            var attr = (XmlAttribute)attrObj;
                            element.Attributes[attr.Name] = attr.Value;
                        }
                    }

                    list.Add(element);
                    break;
            }
        }

        return list;
    }
}