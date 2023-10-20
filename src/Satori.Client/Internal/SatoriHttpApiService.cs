using System.Net.Http.Json;

namespace Satori.Client.Internal;

internal class SatoriHttpApiService : ISatoriApiService
{
    private readonly HttpClient _http;

    internal SatoriHttpApiService(Uri baseUri, string? token)
    {
        _http = new HttpClient { BaseAddress = baseUri };

        if (token is not null)
            _http.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
    }

    public async Task<TData> SendAsync<TData>(string endpoint, string platform, string selfId, object? body)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, endpoint);
        request.Headers.Add("X-Platform", platform);
        request.Headers.Add("X-Self-ID", selfId);
        request.Content = JsonContent.Create(body);

        var response = await _http.SendAsync(request);

        var data = await response.Content.ReadFromJsonAsync<TData>(SatoriClient.JsonOptions);
        return data!;
    }
}