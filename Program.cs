using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{
    private static void Main(string[] args)
    {
        var host = new HostBuilder()
        .ConfigureFunctionsWebApplication()
        .ConfigureServices(services =>
        {
            services.AddApplicationInsightsTelemetryWorkerService();
            services.ConfigureFunctionsApplicationInsights();
            services.AddMyService();
        })
        .Build();

        host.Run();
    }
}

public static class Extensions
{
    public static void AddMyService(this IServiceCollection services)
    {
        services.AddSingleton(new MyService());
        //services.AddSingleton<IMyService, MyService>();
    }
}