using System.Text.Json;
using LiftDataIntegration.Entity.Model.Request;
using LiftDataIntegration.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace LiftDataIntegration.FunctionApp;

public class Fun_ChangeBuildingStatus
{
    private readonly ILogger<Fun_ChangeBuildingStatus> _logger;
    private readonly IBuildingService _buildingService;
    public Fun_ChangeBuildingStatus(IBuildingService buildingService,ILogger<Fun_ChangeBuildingStatus> logger)
    {
        _logger = logger;
        _buildingService= buildingService;  
    }

    [Function("Fun_ChangeBuildingStatus")]
    public async Task <IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
    {
        try
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            var reuestbody = await new StreamReader(req.Body).ReadToEndAsync();
            var body = JsonSerializer.Deserialize<ChangeStatusEntity>(reuestbody);
            var result = _buildingService.ChangeStatus(body);

            return new OkObjectResult(result);
        }
        catch (Exception ex)
        {
            return new OkObjectResult(new { status = 200, message = ex.Message });
        }
    }
}