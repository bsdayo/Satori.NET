namespace Satori.Protocol.Events;

public enum SignalOperation
{
    /// <summary>
    /// 事件
    /// </summary>
    Event = 0,

    /// <summary>
    /// 心跳
    /// </summary>
    Ping = 1,

    /// <summary>
    /// 心跳回复
    /// </summary>
    Pong = 2,

    /// <summary>
    /// 鉴权
    /// </summary>
    Identify = 3,

    /// <summary>
    /// 鉴权回复
    /// </summary>
    Ready = 4
}