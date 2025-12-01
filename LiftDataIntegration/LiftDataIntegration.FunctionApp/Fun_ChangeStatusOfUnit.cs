using System.Text.Json;
using LiftDataIntegration.Entity.Model.Request;
using LiftDataIntegration.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace LiftDataIntegration.FunctionApp;

public class Fun_ChangeStatusOfUnit
{
    private readonly ILogger<Fun_ChangeStatusOfUnit> _logger;
    private readonly IUnitService _unitService;
  public Fun_ChangeStatusOfUnit(IUnitService unitService,ILogger<Fun_ChangeStatusOfUnit> logger)
    {
        _logger = logger;
        _unitService=unitService;
    }

    [Function("Fun_ChangeStatusOfUnit")]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        var requestbody= await new StreamReader(req.Body).ReadToEndAsync();

        var body = JsonSerializer.Deserialize<ChangeStatusOfUnitEntity>(requestbody);
        var result =_unitService.ChangeStatusOfUnit(body);
        return new OkObjectResult(result);
    }
}