namespace Rc.TBank.SDK.Core.Helpers;

public class HttpService
{
    private readonly HttpClient _httpClient;

    public HttpService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<HttpResponseMessage> PostAsync(Uri url, HttpContent content)
    {
        return _httpClient.PostAsync(url, content);
    }
}