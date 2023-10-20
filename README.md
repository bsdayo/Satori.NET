<div align="center">

# Satori.NET

[Satori 协议](https://satori.js.org/zh-CN/) .NET SDK

![Satori Protocol Version](https://img.shields.io/badge/Satori_Protocol-v1-8d80e6)
![.NET Version](https://img.shields.io/badge/.NET-6-512bd4)

</div>

## Satori.Protocol

### 功能

- 协议核心部分，包含消息元素、事件、模型定义
- 支持对 [消息元素](https://satori.js.org/zh-CN/protocol/elements.html) 的序列化与反序列化

## Satori.Client

### 功能

- 对接 Satori 协议的客户端

### 示例

[Satori.Client.Example](./examples/Satori.Client.Example)

## 备注

目前 Satori 那边总还有种没做完的感觉，例如[没有规范的错误信息](https://github.com/satorijs/satori/issues/172)，[部分接口实际返回值与文档不符](https://github.com/satorijs/satori/issues/173)等。
所以本 SDK 目前虽然基本完成，但仍可能遇到些许小问题，如果遇到可以发布 [Issue](https://github.com/bsdayo/Satori.NET/issues/)。

## 开源

[MIT License](./LICENSE)
