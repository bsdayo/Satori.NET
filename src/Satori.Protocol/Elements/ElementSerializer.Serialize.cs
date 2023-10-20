using System.Text;
using System.Xml;

namespace Satori.Protocol.Elements;

public static partial class ElementSerializer
{
    private static readonly string[] ElementPropertyNames =
        typeof(Element).GetProperties().Select(elementProp => elementProp.Name).ToArray();

    private static XmlNode GetXmlNode(XmlDocument document, Element element)
    {
        if (element is TextElement te)
            return document.CreateTextNode(te.Text);

        if (element.TagName is null)
            throw ElementException.TagNameIsNull(element.GetType());

        var xmlElement = document.CreateElement(element.TagName);

        var props = element.GetType().GetProperties();

        foreach (var prop in props)
        {
            if (ElementPropertyNames.Contains(prop.Name))
                continue;

            if (prop.GetValue(element) is not { } attrVal)
                continue;

            var attrName = ConvertPascalToKebab(prop.Name);

            xmlElement.SetAttribute(attrName, attrVal.ToString());
        }

        return xmlElement;
    }

    private static string WriteXmlNode(XmlNode node)
    {
        using var strWriter = new StringWriter();
        using var xmlWriter = XmlWriter.Create(strWriter, new XmlWriterSettings
        {
            OmitXmlDeclaration = true,
            ConformanceLevel = ConformanceLevel.Fragment,
            Indent = false
        });

        node.WriteTo(xmlWriter);
        xmlWriter.Flush();
        return strWriter.ToString();
    }

    public static string Serialize(Element element)
    {
        var document = new XmlDocument();
        var xmlNode = GetXmlNode(document, element);

        foreach (var childElement in element.ChildElements)
            xmlNode.AppendChild(GetXmlNode(document, childElement));

        return WriteXmlNode(xmlNode);
    }

    public static string Serialize(Element[] elements)
    {
        var document = new XmlDocument();
        var sb = new StringBuilder();

        foreach (var element in elements)
        {
            var xmlNode = GetXmlNode(document, element);

            foreach (var childElement in element.ChildElements)
                xmlNode.AppendChild(GetXmlNode(document, childElement));

            sb.Append(WriteXmlNode(xmlNode));
        }

        return sb.ToString();
    }
}