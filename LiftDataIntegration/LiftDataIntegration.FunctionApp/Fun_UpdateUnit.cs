using System.Text.Json;
using LiftDataIntegration.Entity.Model.Request;
using LiftDataIntegration.Service;
using LiftDataIntegration.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace LiftDataIntegration.FunctionApp;

public class Fun_UpdateUnit
{
    private readonly ILogger<Fun_UpdateUnit> _logger;
    private readonly IUnitService _unitService;
   public Fun_UpdateUnit(IUnitService unitService,ILogger<Fun_UpdateUnit> logger)
    {
        _logger = logger;
        _unitService = unitService;
    }

    [Function("Fun_UpdateUnit")]
    public async Task <ActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");

        var requestbody = await new StreamReader(req.Body).ReadToEndAsync();
        var body = JsonSerializer.Deserialize<UpdateUnitEntity>(requestbody);

        var result = _unitService.UpdateUnit(body);
        return new OkObjectResult(result);
    }
}