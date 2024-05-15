<div align="center">

![Satori.NET](./assets/banner.png)

[Satori 协议](https://satori.js.org/zh-CN/) .NET SDK

![Satori Protocol Version](https://img.shields.io/badge/Satori_Protocol-v1-8d80e6)
![.NET Version](https://img.shields.io/badge/.NET-6-512bd4)

**[使用文档](https://docs.bsdayo.moe/Satori.NET/) | [API 参考](https://docs.bsdayo.moe/Satori.NET/api/)**

</div>

|                                 包名                                 |                             版本                             |                                               描述                                               |
|:------------------------------------------------------------------:|:----------------------------------------------------------:|:----------------------------------------------------------------------------------------------:|
| [Satori.Protocol](https://www.nuget.org/packages/Satori.Protocol/) | ![Version](https://img.shields.io/nuget/v/Satori.Protocol) | 协议核心部分，包含消息元素、事件、模型定义；支持对 [消息元素](https://satori.js.org/zh-CN/protocol/elements.html) 的序列化与反序列化 |
|   [Satori.Client](https://www.nuget.org/packages/Satori.Client/)   |  ![Version](https://img.shields.io/nuget/v/Satori.Client)  |                                        对接 Satori 协议的客户端                                        |

## 消息元素

Satori 使用[消息元素](https://satori.js.org/zh-CN/protocol/elements.html)来表示一个消息的内容，形式类似于 HTML。例如：

```html
<!-- 提及 (@) 用户 -->
<at id="1a2b3c4d5e6f"/>

<!-- 引用（回复）消息 -->
<quote id="1f1e33">
    <!-- 提及某个频道 -->
    <sharp id="channel_id"/>
    Hello Satori!
</quote>
```

Satori.NET 支持使用 ElementSerializer 类对消息元素进行序列化与反序列化。

### 序列化

将一个 [Element](https://github.com/bsdayo/Satori.NET/blob/main/src/Satori.Protocol/Elements/Element.cs) 对象序列化为字符串：

```csharp
var element = new ImageElement
{
    Src = "https://example.com/img.jpg",
    Width = 114514,
    Height = 1919810
};

// <img width="114514" height="1919810" src="https://example.com/img.jpg" />
var text = ElementSerializer.Serialize(element);
```

支持一个 Element 数组：

```csharp
var element1 = new AuthorElement { UserId = "satori" };
var element2 = new SharpElement { Id = "satori-channel" };
var element3 = new TextElement { Text = "text" };

// <author user-id="satori" /><sharp id="satori-channel" />text
var text = ElementSerializer.Serialize(new Element[] { element1, element2, element3 });
```

### 反序列化

将一个字符串反序列化为 Element\[\]：

```csharp
var text = "<a href=\"https://example.com\">Test</a>";
var elements = ElementSerializer.Deserialize(text);

// elements[0]: LinkElement
// elements[0].ChildElements[0]: TextElement
```

## 示例

[Satori.Client.Example](./examples/Satori.Client.Example)

## 备注

本 SDK 目前虽然基本完成，仍可能遇到些许小问题，如果遇到可以发布 [Issue](https://github.com/bsdayo/Satori.NET/issues/)。

## 开源

[MIT License](https://github.com/bsdayo/Satori.NET/blob/main/LICENSE)
