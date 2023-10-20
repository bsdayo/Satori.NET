namespace Satori.Protocol.Elements;

/// <summary>
/// 提及频道
/// </summary>
public class SharpElement : Element
{
    public override string TagName => "sharp";

    /// <summary>
    /// 目标频道的 ID
    /// </summary>
    public string Id { get; set; } = "";

    /// <summary>
    /// 目标频道的名称
    /// </summary>
    public string? Name { get; set; }
}