namespace Satori.Protocol.Models;

/// <summary>
/// 登录信息
/// </summary>
public class Login
{
    /// <summary>
    /// 用户对象
    /// </summary>
    public User? User { get; set; }

    /// <summary>
    /// 平台账号
    /// </summary>
    public string? SelfId { get; set; }

    /// <summary>
    /// 平台名称
    /// </summary>
    public string? Platform { get; set; }

    /// <summary>
    /// 登陆状态
    /// </summary>
    public Status Status { get; set; }
}

public enum Status
{
    /// <summary>
    /// 离线
    /// </summary>
    Offline = 0,

    /// <summary>
    /// 在线
    /// </summary>
    Online = 1,

    /// <summary>
    /// 连接中
    /// </summary>
    Connect = 2,

    /// <summary>
    /// 断开连接
    /// </summary>
    Disconnect = 3,

    /// <summary>
    /// 重新连接
    /// </summary>
    Reconnect = 4
}