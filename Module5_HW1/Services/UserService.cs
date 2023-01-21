using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Module5_HW1.Config;
using Module5_HW1.DTO;
using Module5_HW1.DTO.Responses;
using Module5_HW1.Models;
using Module5_HW1.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace Module5_HW1.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly ApiOption _apiOption;

        public UserService(
            IHttpClientService httpClientService,
            IOptions<ApiOption> options)
        {
            _httpClientService = httpClientService;
            _apiOption = options.Value;
        }

        public async Task<User> GetUserById(int id)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var response =
                    await _httpClientService
                    .SendAsync<PagingResponse<UserDTO>>(
                        $"{_apiOption.Host}/users/{id}",
                        HttpMethod.Get);

                if (response!.Data != null)
                {
                    return new User
                    {
                        Email = response.Data.Email,
                        FirstName = response.Data.FirstName,
                        Id = response.Data.Id,
                        LastName = response.Data.LastName,
                        UrlAvatar = response.Data.AvatarURL
                    };
                }

                return null!;
            });
        }

        public async Task<Collection<User>> GetUsersByPage(int page)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var response =
                    await _httpClientService
                    .SendAsync<PagingResponse<UserDTO[]>>(
                        $"{_apiOption.Host}/users?page={page}",
                        HttpMethod.Get);

                if (response!.Data != null)
                {
                    return new Collection<User>()
                    {
                        Data = response.Data.Select(s => new User
                        {
                            Email = s.Email,
                            FirstName = s.FirstName,
                            Id = s.Id,
                            LastName = s.LastName,
                            UrlAvatar = s.AvatarURL
                        }).ToList()
                    };
                }

                return null!;
            });
        }

        public async Task<Collection<User>> GetUsersByDelay(int delay)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var response =
                    await _httpClientService
                    .SendAsync<PagingResponse<UserDTO[]>>(
                        $"{_apiOption.Host}/users?delay={delay}",
                        HttpMethod.Get);

                if (response!.Data != null)
                {
                    return new Collection<User>()
                    {
                        Data = response.Data.Select(s => new User
                        {
                            Email = s.Email,
                            FirstName = s.FirstName,
                            Id = s.Id,
                            LastName = s.LastName,
                            UrlAvatar = s.AvatarURL
                        }).ToList()
                    };
                }

                return null!;
            });
        }

        public async Task<Employee> CreateUserEmployee(string name, string job)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var request = new EmployeeDTO { Name = name, Job = job };
                var response =
                    await _httpClientService
                    .SendAsync<EmployeeDTO>(
                        $"{_apiOption.Host}/users",
                        HttpMethod.Post,
                        request);

                if (response != null)
                {
                    return new Employee
                    {
                        CreatedAt = response.CreatedAt,
                        Job = response.Job,
                        Id = response.Id,
                        Name = response.Name,
                        UpdatedAt = response.UpdatedAt
                    };
                }

                return null!;
            });
        }

        public async Task<Employee> UpdateUserEmployeeById(
            int id,
            string name,
            string job)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var request = new EmployeeDTO
                {
                    Name = name,
                    Job = job
                };
                var response =
                    await _httpClientService
                    .SendAsync<EmployeeDTO>(
                        $"{_apiOption.Host}/users/{id}",
                        HttpMethod.Put,
                        request);

                if (response != null)
                {
                    return new Employee
                    {
                        CreatedAt = response.CreatedAt,
                        Job = response.Job,
                        Id = response.Id,
                        Name = response.Name,
                        UpdatedAt = response.UpdatedAt
                    };
                }

                return null!;
            });
        }

        public async Task<Employee> ModifyUserEmployeeById(
            int id,
            string name,
            string job)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var request = new EmployeeDTO
                {
                    Name = name,
                    Job = job
                };
                var response =
                    await _httpClientService
                    .SendAsync<EmployeeDTO>(
                        $"{_apiOption.Host}/users/{id}",
                        HttpMethod.Patch,
                        request);

                if (response != null)
                {
                    return new Employee
                    {
                        CreatedAt = response.CreatedAt,
                        Job = response.Job,
                        Id = response.Id,
                        Name = response.Name,
                        UpdatedAt = response.UpdatedAt
                    };
                }

                return null!;
            });
        }

        public async Task<VoidResult> RemoveUserEmployeeById(int id)
        {
            return await ExecuteSafeAsync<VoidResult>(async () =>
            {
                await _httpClientService
                .SendAsync(
                    $"{_apiOption.Host}/users/{id}",
                    HttpMethod.Delete);
                return null!;
            });
        }
    }
}
