using LiftDataIntegration.Entity.Model.Request;
using System.Text.Json;
using LiftDataIntegration.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace LiftDataIntegration.FunctionApp;

public class Fun_UpdateBuilding
{
    private readonly ILogger<Fun_UpdateBuilding> _logger;
    private readonly IBuildingService _buildingService;
    public Fun_UpdateBuilding(IBuildingService buildingService,ILogger<Fun_UpdateBuilding> logger)
    {
        _logger = logger;
        _buildingService = buildingService;
    }

    [Function("Fun_UpdateBuilding")]
    public async Task <IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");


        var requestbody = await new StreamReader(req.Body).ReadToEndAsync();
        var body = JsonSerializer.Deserialize<UpdateBuildingEntity>(requestbody);

        var result = _buildingService.UpdateBuilding(body);
        return new OkObjectResult(result);
    }
}