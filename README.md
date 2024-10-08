# Example of isolation troubleshooting by removing the Injected Services


- Below shows the host response to the URL `https://webjoblintest56aspfa.azurewebsites.net/` after deployment of the code in this repository

![image](https://github.com/user-attachments/assets/3e2c0446-b2fd-49bd-ad1d-3ba2cf7e4911)

- Then attempting to hit the `/api/http1` endpoint we will see a failed execution, as the Funtion Host is in an unhealthy state

![image](https://github.com/user-attachments/assets/5921420b-bc36-458a-9015-5f33a0d87bdf)

Finally, by changing the `Program.cs`, removing the Injected Services, we can confirm if there is a configuration issue or a failure in the Function Host

```csharp
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
        })
        .Build();

        host.Run();
    }
}
```
