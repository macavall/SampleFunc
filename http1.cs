using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace functemp
{
    public class http1
    {
        private readonly ILogger<http1> _logger;
        private readonly IMyService _myService;

        public http1(ILogger<http1> logger, IMyService myService)
        {
            _logger = logger;
            _myService = myService;
        }

        [Function("http1")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            _myService.MyWork();

            return new OkObjectResult("Welcome to Azure Functions!");
        }
    }
}
