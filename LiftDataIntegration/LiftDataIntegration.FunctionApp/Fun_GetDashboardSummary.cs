using System.Threading.Tasks;
using LiftDataIntegration.Entity.Model.Response;
using LiftDataIntegration.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace LiftDataIntegration.FunctionApp;

public class Fun_GetDashboardSummary
{
    private readonly ILogger<Fun_GetDashboardSummary> _logger;
    private readonly IDashboardService _summaryResponse;
    public Fun_GetDashboardSummary(IDashboardService summaryResponse,ILogger<Fun_GetDashboardSummary> logger)
    {
        _logger = logger;
        _summaryResponse = summaryResponse;
    }

    [Function("Fun_GetDashboardSummary")]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
    {
        try
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");


            string date = (req.Query["RunDate"]);
            var result = _summaryResponse.GetDashboardSummary(date);
            return new OkObjectResult(result);
        }
        catch (Exception ex)
        {

            return new OkObjectResult(new { status = 200, ex.Message });
        }
    }
}