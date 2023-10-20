using Satori.Protocol.Models;

namespace Satori.Client;

public partial class SatoriBot
{
    /// <summary>
    /// 获取群组频道
    /// </summary>
    /// <param name="channelId"></param>
    public Task<Channel> GetChannelAsync(string channelId)
    {
        return SendAsync<Channel>("/v1/channel.get", new
        {
            channel_id = channelId
        });
    }

    // /// <summary>
    // /// 获取群组频道列表
    // /// </summary>
    // /// <param name="guildId"></param>
    // /// <param name="next"></param>
    // /// <returns></returns>
    // Task<DataPagination<Channel>> ListChannelAsync(string guildId, string? next = null);
    //
    // /// <summary>
    // /// 创建群组频道
    // /// </summary>
    // /// <param name="guildId"></param>
    // /// <param name="data"></param>
    // /// <returns></returns>
    // Task<Channel> CreateChannelAsync(string guildId, Channel data);
    //
    // /// <summary>
    // /// 修改群组频道
    // /// </summary>
    // /// <param name="channelId"></param>
    // /// <param name="data"></param>
    // /// <returns></returns>
    // Task UpdateChannelAsync(string channelId, Channel data);
    //
    // /// <summary>
    // /// 删除群组频道
    // /// </summary>
    // /// <param name="channelId"></param>
    // /// <returns></returns>
    // Task DeleteChannelAsync(string channelId);
    //
    // /// <summary>
    // /// 创建一个私聊频道
    // /// </summary>
    // /// <param name="userId"></param>
    // /// <returns></returns>
    // Task<Channel> CreateUserChannelAsync(string userId);
}