using Satori.Client;
using Satori.Protocol.Elements;

Console.Write("Input Token: ");
var token = Console.ReadLine()?.Trim() ?? "";

Console.Write("Input Platform: ");
var platform = Console.ReadLine()?.Trim() ?? "";

Console.Write("Input SelfId: ");
var selfId = Console.ReadLine()?.Trim() ?? "";

using var client = new SatoriClient("http://localhost:5500", token);

client.Logging += (_, log) => { Console.WriteLine($"[{log.LogTime}] [{log.LogLevel}] {log.Message}"); };

var bot = client.Bot(platform, selfId);

await client.StartAsync();

bot.MessageCreated += async (_, e) =>
{
    Console.WriteLine($"Received message from {e.Channel!.Id}: {e.Message!.Content}");
    await bot.CreateMessageAsync(e.Channel.Id,
        new TextElement { Text = "非常好 Satori，爱来自 Satori.Client" });
};

await Task.Delay(-1);