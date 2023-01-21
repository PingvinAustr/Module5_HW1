using System.Net.Http;
using System.Threading.Tasks;

namespace Module5_HW1.Services.Interfaces;
public interface IHttpClientService
{
    Task<TResponse> SendAsync<TResponse>(
        string url,
        HttpMethod method,
        object? content = null);
    Task SendAsync(
        string url,
        HttpMethod method,
        object? content = null);
}
