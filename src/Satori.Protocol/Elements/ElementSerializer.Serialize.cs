using System.Text;
using System.Xml;
using HtmlAgilityPack;

namespace Satori.Protocol.Elements;

public static partial class ElementSerializer
{
    private static readonly string[] ElementPropertyNames =
        typeof(Element).GetProperties().Select(elementProp => elementProp.Name).ToArray();

    private static HtmlNode GetHtmlNode(HtmlDocument document, Element element)
    {
        if (element is TextElement te)
            return document.CreateTextNode(te.Text);

        if (element.TagName is null)
            throw ElementException.TagNameIsNull(element.GetType());

        var htmlElement = document.CreateElement(element.TagName);

        var props = element.GetType().GetProperties();

        foreach (var prop in props)
        {
            if (ElementPropertyNames.Contains(prop.Name))
                continue;

            if (prop.GetValue(element) is not { } attrVal)
                continue;

            var attrName = ConvertPascalToKebab(prop.Name);

            htmlElement.SetAttributeValue(attrName, attrVal.ToString());
        }

        return htmlElement;
    }

    private static string WriteHtmlNode(HtmlNode node)
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
        var document = new HtmlDocument();
        var htmlNode = GetHtmlNode(document, element);

        foreach (var childElement in element.ChildElements)
            htmlNode.AppendChild(GetHtmlNode(document, childElement));

        return WriteHtmlNode(htmlNode);
    }

    public static string Serialize(Element[] elements)
    {
        var document = new HtmlDocument();
        var sb = new StringBuilder();

        foreach (var element in elements)
        {
            var xmlNode = GetHtmlNode(document, element);

            foreach (var childElement in element.ChildElements)
                xmlNode.AppendChild(GetHtmlNode(document, childElement));

            sb.Append(WriteHtmlNode(xmlNode));
        }

        return sb.ToString();
    }
}