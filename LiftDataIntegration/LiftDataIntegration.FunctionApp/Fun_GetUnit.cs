using DocumentFormat.OpenXml.Spreadsheet;
using LiftDataIntegration.Service;
using LiftDataIntegration.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace LiftDataIntegration.FunctionApp;

public class Fun_GetUnit
{
    private readonly ILogger<Fun_GetUnit> _logger;
    private readonly IGetUnitService _GetUnitSevice;
    public Fun_GetUnit(IGetUnitService GetUnitSevice,ILogger<Fun_GetUnit> logger)
    {
        _logger = logger;
        _GetUnitSevice = GetUnitSevice;
    }

    [Function("Fun_GetUnit")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");

        int request = Convert.ToInt32(req.Query["id"]);

        var result = _GetUnitSevice.GetUnit(request);
        return new OkObjectResult(result);
    }
}