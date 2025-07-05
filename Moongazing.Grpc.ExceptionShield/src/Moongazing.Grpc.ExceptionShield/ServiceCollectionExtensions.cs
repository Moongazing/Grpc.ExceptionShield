using Microsoft.Extensions.DependencyInjection;

namespace Moongazing.Grpc.ExceptionShield;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddGrpcExceptionShield(this IServiceCollection services)
    {
        services.AddSingleton<IExceptionMapper, DefaultExceptionMapper>();
        services.AddSingleton<GrpcExceptionInterceptor>();
        return services;
    }
}
