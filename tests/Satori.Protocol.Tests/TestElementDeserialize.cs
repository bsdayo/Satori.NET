using Satori.Protocol.Elements;

namespace Satori.Protocol.Tests;

public class TestElementDeserialize
{
    [Fact]
    public void TestDeserialize()
    {
        const string text = "<a href=\"https://example.com\">Test</a>";
        var elements = ElementSerializer.Deserialize(text).ToArray();

        Assert.Single(elements);
        Assert.Single(elements[0].ChildElements);

        Assert.Equal("a", elements[0].TagName);
        Assert.IsType<LinkElement>(elements[0]);
        Assert.Equal("https://example.com", ((LinkElement)elements[0]).Href);

        var child = elements[0].ChildElements[0];
        Assert.IsType<TextElement>(child);
        Assert.Equal("Test", ((TextElement)child).Text);
    }

    [Fact]
    public void TestMultiple()
    {
        const string text = "aaaaa<message forward />bbbbb";
        var elements = ElementSerializer.Deserialize(text).ToArray();

        Assert.Equal(3, elements.Length);
        Assert.IsType<TextElement>(elements[0]);
        Assert.IsType<MessageElement>(elements[1]);
        Assert.IsType<TextElement>(elements[2]);

        Assert.True(((MessageElement)elements[1]).Forward);
    }
}