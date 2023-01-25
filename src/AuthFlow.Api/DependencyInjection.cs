using AuthFlow.Api.Common.Mapper;

namespace AuthFlow.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSwaggerGen();
        services.AddMappings();

        return services;
    }
}