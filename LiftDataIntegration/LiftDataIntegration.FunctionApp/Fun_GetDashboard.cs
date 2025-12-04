using LiftDataIntegration.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace LiftDataIntegration.FunctionApp;

public class Fun_GetDashboard
{
    private readonly ILogger<Fun_GetDashboard> _logger;
    private readonly IDashboardService _dashboardService;
   public Fun_GetDashboard(IDashboardService dashboardService,ILogger<Fun_GetDashboard> logger)
    {
        _logger = logger;
        _dashboardService=dashboardService;
    }

    [Function("Fun_GetDashboard")]
    public async Task <IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");

        var result = _dashboardService.GetDashboard();
        return new OkObjectResult(result);

    }
}