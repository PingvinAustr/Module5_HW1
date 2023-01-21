using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Module5_HW1.DTO;
using Module5_HW1.Helpers;
using Module5_HW1.Services.Interfaces;
using Newtonsoft.Json;

namespace Module5_HW1.Services;
public class HttpClientService : IHttpClientService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public HttpClientService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task SendAsync(
        string url,
        HttpMethod method,
        object? content = null)
    {
        var httpMessage = new HttpRequestMessage();
        httpMessage.RequestUri = new Uri(url);
        httpMessage.Method = method;
        if (content != null)
        {
            httpMessage.Content = new StringContent(
                JsonConvert.SerializeObject(content),
                Encoding.UTF8,
                Constants.JsonContentType);
        }

        HttpResponseMessage result;

        try
        {
            var httpClient = _httpClientFactory.CreateClient();
            result = await httpClient.SendAsync(httpMessage);
        }
        catch (Exception ex)
        {
            throw new BusinessException(ex.Message);
        }

        throw new BusinessException(
            null!,
            result.StatusCode.ToString());
    }

    public async Task<TResponse> SendAsync<TResponse>(
        string url,
        HttpMethod method,
        object? content = null)
    {
        var httpMessage = new HttpRequestMessage();
        httpMessage.RequestUri = new Uri(url);
        httpMessage.Method = method;
        if (content != null)
        {
            httpMessage.Content = new StringContent(
                JsonConvert.SerializeObject(content),
                Encoding.UTF8,
                Constants.JsonContentType);
        }

        HttpResponseMessage result;

        try
        {
            var httpClient = _httpClientFactory.CreateClient();
            result = await httpClient.SendAsync(httpMessage);
        }
        catch (Exception ex)
        {
            throw new BusinessException(ex.Message);
        }

        var resultContent = await result.Content.ReadAsStringAsync();

        if (result.IsSuccessStatusCode)
        {
            var response = JsonConvert.DeserializeObject<TResponse>(
                resultContent);

            if (response is ErrorDTO error
                && !string.IsNullOrEmpty(error.Error))
            {
                throw new BusinessException(
                    error.Error,
                    ErrorCodes.Validation);
            }

            return response!;
        }

        throw new BusinessException(
            resultContent,
            result.StatusCode.ToString());
    }
}
