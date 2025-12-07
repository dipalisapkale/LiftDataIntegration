using Azure.Storage.Blobs.Models;
using LiftDataIntegration.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace LiftDataIntegration.FunctionApp;

public class Fun_GetDailyTrend
{
    private readonly ILogger<Fun_GetDailyTrend> _logger;
    private readonly IDashboardService _dashboardService;
    public Fun_GetDailyTrend(IDashboardService dashboardService,ILogger<Fun_GetDailyTrend> logger)
    {
        _logger = logger;
        _dashboardService= dashboardService;
    }

    [Function("Fun_GetDailyTrend")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
    {
        try
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            int day = Convert.ToInt32(req.Query["Day"]); 
           var result =  _dashboardService.GetDailyTrend(day);
            return new OkObjectResult(result);

        }
        catch (Exception ex)
        {

            return new OkObjectResult(new { status = 200, ex.Message }); 
        }
    }
}