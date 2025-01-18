using WebFileManagementSystem.Service.Services;
using WebFileManagementSystem.StorageBroker.Services;

namespace WebFileManagementSystem.Server.DependencyInjection;

public static class DependecyInjectionExtensions
{
    public static IServiceCollection MyAddScoped(this IServiceCollection services)
    {
        return services.AddScoped<IStorageService, StorageService>();
    }
    public static IServiceCollection MyAddSingleton(this IServiceCollection services)
    {
        return services.AddSingleton<IStorageBrokerService, LocalStorageBrokerService>();
    }
}
