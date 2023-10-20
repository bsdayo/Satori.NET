using Satori.Protocol.Models;

namespace Satori.Protocol.Events;

public class ReadySignalBody
{
    public IEnumerable<Login> Logins { get; set; } = Array.Empty<Login>();
}