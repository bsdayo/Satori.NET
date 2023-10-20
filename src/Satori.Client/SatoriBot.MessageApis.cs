using System.Text;
using Satori.Protocol.Elements;
using Satori.Protocol.Models;

namespace Satori.Client;

public partial class SatoriBot
{
    public Task<Message[]> CreateMessageAsync(string channelId, IEnumerable<Element> content)
    {
        var sb = new StringBuilder();
        foreach (var element in content)
            sb.Append(ElementSerializer.Serialize(element));

        return SendAsync<Message[]>("/v1/message.create", new
        {
            channel_id = channelId,
            content = sb.ToString()
        });
    }
}