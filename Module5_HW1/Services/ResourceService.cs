using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Module5_HW1.Config;
using Module5_HW1.DTO;
using Module5_HW1.DTO.Responses;
using Module5_HW1.Models;
using Module5_HW1.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace Module5_HW1.Services;

public class ResourceService : BaseService, IResourceService
{
    private readonly IHttpClientService _httpClientService;
    private readonly ApiOption _apiOption;

    public ResourceService(
        IHttpClientService httpClientService,
        IOptions<ApiOption> options)
    {
        _apiOption = options.Value;
        _httpClientService = httpClientService;
    }

    public async Task<Resource> GetResourceById(int id)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var response =
                await _httpClientService
                .SendAsync<PagingResponse<ResourceDTO>>(
                    $"{_apiOption.Host}/unknown/{id}",
                    HttpMethod.Get);

            if (response!.Data != null)
            {
                return new Resource
                {
                    Color = response.Data.Color,
                    Name = response.Data.Name,
                    Id = response.Data.Id,
                    PantoneValue = response.Data.PantoneValue,
                    Year = response.Data.Year
                };
            }

            return null!;
        });
    }

    public async Task<Collection<Resource>> GetAllResources()
    {
        return await ExecuteSafeAsync(async () =>
        {
            var response =
                await _httpClientService
                .SendAsync<PagingResponse<ResourceDTO[]>>(
                    $"{_apiOption.Host}/unknown",
                    HttpMethod.Get);

            if (response!.Data != null)
            {
                return new Collection<Resource>()
                {
                    Data = response.Data.Select(s => new Resource
                    {
                        Color = s.Color,
                        Name = s.Name,
                        Id = s.Id,
                        PantoneValue = s.PantoneValue,
                        Year = s.Year
                    }).ToList()
                };
            }

            return null!;
        });
    }
}