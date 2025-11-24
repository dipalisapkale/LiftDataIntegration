using System.Net.WebSockets;
using System.Text.Json;
using System.Text.Json.Serialization;
using LiftDataIntegration.Entity.Model.Request;
using LiftDataIntegration.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace LiftDataIntegration.FunctionApp;

public class Fun_PostBuilding
{
    private readonly ILogger<Fun_PostBuilding> _logger;
    private readonly IBuildingService _buildingService;
    public Fun_PostBuilding(IBuildingService buildingService,ILogger<Fun_PostBuilding> logger)
    {
        _logger = logger;
        _buildingService = buildingService;
    }

    [Function("Fun_PostBuilding")]
    public async Task <IActionResult> PostBuilding([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");

        var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        var Data = JsonSerializer.Deserialize<PostBuildingEntity>(requestBody);

        var result = _buildingService.PostBuilding(Data);
        return new OkObjectResult(result);
    }
}