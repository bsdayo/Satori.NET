using System.Xml;
using Satori.Protocol.Elements;

namespace Satori.Protocol.Tests;

public class TestElementSerialize
{
    /// <summary>
    /// 测试单个元素
    /// </summary>
    [Fact]
    public void TestNormal()
    {
        var element = new ImageElement
        {
            Src = "https://example.com/img.jpg",
            Width = 114514,
            Height = 1919810
        };

        var text = ElementSerializer.Serialize(element);
        var document = new XmlDocument();
        document.LoadXml(text);
        var root = document.DocumentElement!;

        Assert.Equal("img", root.Name);
        Assert.Equal(3, root.Attributes.Count);
        Assert.Equal("https://example.com/img.jpg", root.GetAttribute("src"));
        Assert.Equal("114514", root.GetAttribute("width"));
        Assert.Equal("1919810", root.GetAttribute("height"));
    }

    /// <summary>
    /// 测试包含子元素的元素
    /// </summary>
    [Fact]
    public void TestChildElement()
    {
        var element = new MessageElement
        {
            Forward = true,
            ChildElements =
            {
                new TextElement { Text = "Test Text" },
                new LinkElement { Href = "https://example.com" }
            }
        };

        var text = ElementSerializer.Serialize(element);
        var document = new XmlDocument();
        document.LoadXml(text);
        var root = document.DocumentElement!;

        Assert.Equal("message", root.Name);
        Assert.Equal("true", root.GetAttribute("forward"), StringComparer.CurrentCultureIgnoreCase);
        Assert.Equal(2, root.ChildNodes.Count);

        Assert.Equal(XmlNodeType.Text, root.ChildNodes[0]?.NodeType);
        Assert.Equal("Test Text", root.ChildNodes[0]?.InnerText);

        Assert.Equal("a", root.ChildNodes[1]?.Name);
        Assert.Equal("https://example.com", ((XmlElement?)root.ChildNodes[1])?.GetAttribute("href"));
    }

    /// <summary>
    /// 测试多个元素并列（实际上并不是合法的 XML 文档，但却是合法的 Satori 消息内容）
    /// </summary>
    [Fact]
    public void TestMultipleElements()
    {
        var element1 = new AuthorElement { UserId = "satori" };
        var element2 = new SharpElement { Id = "satori-channel" };
        var element3 = new TextElement { Text = "text" };

        var text = ElementSerializer.Serialize(new Element[] { element1, element2, element3 });
        var document = new XmlDocument();
        document.LoadXml($"<wrapper>{text}</wrapper>");
        var root = document.DocumentElement!;

        Assert.Equal(3, root.ChildNodes.Count);

        Assert.Equal("author", root.ChildNodes[0]?.Name);
        Assert.Equal("satori", ((XmlElement?)root.ChildNodes[0])?.GetAttribute("user-id"));

        Assert.Equal("sharp", root.ChildNodes[1]?.Name);
        Assert.Equal("satori-channel", ((XmlElement?)root.ChildNodes[1])?.GetAttribute("id"));

        Assert.Equal(XmlNodeType.Text, root.ChildNodes[2]?.NodeType);
        Assert.Equal("text", root.ChildNodes[2]?.InnerText);
    }
}