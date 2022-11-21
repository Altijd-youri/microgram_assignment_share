using Microsoft.Extensions.DependencyInjection;

namespace Cuniculus;

public static class CuniculusHostedServiceExtension
{
    public static void AddCuniculus(this IServiceCollection services, string exchangeName, string queueName) {
        services.AddSingleton<ICuniculusOptions>(
            new CuniculusOptions(exchangeName,queueName)
        );
        services.AddSingleton<ICuniculusContext, CuniculusContext>();
        services.AddTransient<IBasicSender, BasicSender>();
        services.AddTransient<IBasicReceiver, BasicReceiver>();
        services.AddHostedService<CuniculusHostedService>();
    }
}