using System.Net.WebSockets;
using System.Text.Json;
using Satori.Protocol.Events;
using Websocket.Client;
using Timer = System.Timers.Timer;

namespace Satori.Client.Internal;

internal sealed class SatoriWebSocketEventService : ISatoriEventService, IDisposable
{
    private readonly WebsocketClient _ws;
    private readonly Uri _wsUri;
    private readonly string? _token;
    private readonly SatoriClient _client;
    private readonly Timer _pingTimer;

    public event EventHandler<Event>? EventReceived;

    public SatoriWebSocketEventService(Uri baseUri, string? token, SatoriClient client)
    {
        _wsUri = new Uri(new UriBuilder(baseUri) { Scheme = "ws" }.Uri,
            new Uri("/v1/events", UriKind.Relative));
        _ws = new WebsocketClient(_wsUri);
        _token = token;
        _client = client;

        _ws.MessageReceived.Subscribe(OnMessageReceived);
        _ws.DisconnectionHappened.Subscribe(OnDisconnectionHappened);
        _ws.ReconnectionHappened.Subscribe(OnReconnectionHappened);

        _pingTimer = new Timer
        {
            AutoReset = true,
            Interval = TimeSpan.FromSeconds(10).TotalMilliseconds
        };
        _pingTimer.Elapsed += (_, _) => SendSignal(new Signal { Op = SignalOperation.Ping });
    }

    private void SendSignal<T>(T signal) where T : Signal
    {
        var text = JsonSerializer.Serialize(signal, SatoriClient.JsonOptions);
        _client.Log(LogLevel.Trace, $"WebSocket --Send-> {text}");
        _ws.Send(text);
    }

    private void OnMessageReceived(ResponseMessage message)
    {
        try
        {
            _client.Log(LogLevel.Trace, $"WebSocket <-Recv-- {message}");
            var json = JsonDocument.Parse(message.Text!);
            var op = (SignalOperation)json.RootElement.GetProperty("op").GetInt32();

            switch (op)
            {
                case SignalOperation.Event:
                    EventReceived?.Invoke(this, json.Deserialize<Signal<Event>>(SatoriClient.JsonOptions)!.Body!);
                    break;
            }
        }
        catch (Exception e)
        {
            _client.Log(e);
        }
    }

    private void OnDisconnectionHappened(DisconnectionInfo info)
    {
        _client.Log(LogLevel.Information, $"WebSocket disconnected. Status: {info.CloseStatus}");
    }

    private void OnReconnectionHappened(ReconnectionInfo info)
    {
        if (info.Type == ReconnectionType.Initial)
            return;

        _client.Log(LogLevel.Information, "WebSocket reconnecting...");
    }

    public async Task StartAsync()
    {
        _client.Log(LogLevel.Debug, $"Connecting to {_wsUri}...");
        await _ws.StartOrFail();

        var identify = new Signal<IdentifySignalBody>
        {
            Op = SignalOperation.Identify,
            Body = new IdentifySignalBody { Token = _token }
        };
        SendSignal(identify);

        _pingTimer.Start();
    }

    public async Task StopAsync()
    {
        _pingTimer.Stop();
        await _ws.StopOrFail(WebSocketCloseStatus.NormalClosure, "");
    }

    public void Dispose() => _ws.Dispose();
}