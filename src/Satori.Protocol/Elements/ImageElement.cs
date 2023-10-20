namespace Satori.Protocol.Elements;

public class ImageElement : ResourceElement
{
    public override string TagName => "img";

    /// <summary>
    /// 图片的宽度
    /// </summary>
    public int? Width { get; set; }

    /// <summary>
    /// 图片的高度
    /// </summary>
    public int? Height { get; set; }
}