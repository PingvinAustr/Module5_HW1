using Microsoft.Extensions.Options;
using Module5_HW1.Config;
using Module5_HW1.Models;
using Module5_HW1.DTO;
using Module5_HW1.DTO.Responses;

namespace Module5_HW1.Services.Interfaces
{
    public class AuthService : BaseService, IAuthService
    {
        private readonly IHttpClientService _internalHttpClientService;
        private readonly ApiOption _apiOption;

        public AuthService(
            IHttpClientService internalHttpClientService,
            IOptions<ApiOption> options)
        {
            _apiOption = options.Value;
            _internalHttpClientService = internalHttpClientService;
        }

        public async Task<LoginResult> Login(
            string login,
            string password)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var request = new LoginDTO
                {
                    Email = login,
                    Password = password
                };

                var response = await _internalHttpClientService
                .SendAsync<LoginResponse>(
                    $"{_apiOption.Host}/login",
                    HttpMethod.Post,
                    request);
                return new LoginResult
                {
                    Token = response!.Token!
                };
            });
        }

        public async Task<RegisterResult> Register(
            string login,
            string password)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var request = new LoginDTO
                {
                    Email = login,
                    Password = password
                };
                var response = await _internalHttpClientService
                .SendAsync<RegisterResponse>(
                    $"{_apiOption.Host}/register",
                    HttpMethod.Post,
                    request);
                return new RegisterResult
                {
                    Token = response!.Token!
                };
            });
        }
    }
}
