using Satori.Protocol.Elements;

namespace Satori.Protocol.Tests;

public class TestNamingConverters
{
    /// <summary>
    /// 测试从 PascalCase 到 kebab-case 的转换
    /// </summary>
    [Theory]
    [InlineData("SomeText", "some-text")]
    [InlineData("IdData", "id-data")]
    [InlineData("IDData", "i-d-data")]
    public void TestPascalToKebab(string input, string expected)
    {
        var output = ElementSerializer.ConvertPascalToKebab(input);
        Assert.Equal(expected, output);
    }

    /// <summary>
    /// 测试从 kebab-case 到 PascalCase 的转换
    /// </summary>
    [Theory]
    [InlineData("some-text", "SomeText")]
    [InlineData("x-ex-data", "XExData")]
    [InlineData("foo-bar-baz", "FooBarBaz")]
    [InlineData("s-c-p", "SCP")]
    public void TestKebabToPascal(string input, string expected)
    {
        var output = ElementSerializer.ConvertKebabToPascal(input);
        Assert.Equal(expected, output);
    }
}