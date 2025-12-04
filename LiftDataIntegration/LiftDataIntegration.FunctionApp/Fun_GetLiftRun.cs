using Azure.Core;
using LiftDataIntegration.Entity.Model.Request;
using LiftDataIntegration.Service;
using LiftDataIntegration.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace LiftDataIntegration.FunctionApp;

public class Fun_GetLiftRun
{
    private readonly ILogger<Fun_GetLiftRun> _logger;
    private readonly ILiftRunService _liftRunService;
   public Fun_GetLiftRun(ILiftRunService liftRunService,ILogger<Fun_GetLiftRun> logger)
    {
        _logger = logger;
        _liftRunService= liftRunService;
    }

    [Function("Fun_GetLiftRun")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        string No = (req.Query["EquipmentNo"]);
        DateTime? RunDate =Convert.ToDateTime (req.Query["Date"]);

        GetLiftRunRequest request = new GetLiftRunRequest();
        request.EquipmentNo = No;
        request.Date = RunDate;

        var result = _liftRunService.GetLiftRun(request);
        return new OkObjectResult(result);
    }
}