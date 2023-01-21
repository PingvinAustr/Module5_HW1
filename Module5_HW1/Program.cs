using Module5_HW1;
using Module5_HW1.Config;
using Module5_HW1.Services;
using Module5_HW1.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

void ConfigureServices(
    ServiceCollection serviceCollection,
    IConfiguration configuration)
{
    serviceCollection
        .AddOptions<ApiOption>()
        .Bind(configuration.GetSection("Api"));
    serviceCollection
        .AddLogging(configure => configure.AddConsole())
        .AddHttpClient()
        .AddTransient<IHttpClientService, HttpClientService>()
        .AddTransient<IUserService, UserService>()
        .AddTransient<IResourceService, ResourceService>()
        .AddTransient<IAuthService, AuthService>()
        .AddTransient<Starter>();
}

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("config.json")
    .Build();

var serviceCollection = new ServiceCollection();
ConfigureServices(serviceCollection, configuration);
var provider = serviceCollection.BuildServiceProvider();

var app = provider.GetService<Starter>();
await app!.Start();