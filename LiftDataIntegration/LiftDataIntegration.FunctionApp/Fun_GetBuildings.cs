using LiftDataIntegration.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace LiftDataIntegration.FunctionApp;

public class Fun_GetBuildings
{
    private readonly ILogger<Fun_GetBuildings> _logger;
    private readonly IBuildingService _buildingGetAllService;
   
    public Fun_GetBuildings(IBuildingService buildingGetAllService,ILogger<Fun_GetBuildings> logger)
    {
        _logger = logger;
        _buildingGetAllService = buildingGetAllService;
    }

    [Function("Fun_GetBuildings")]
    
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req,string id)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");

           string ID = (req.Query["id"]);

            int Id = Convert.ToInt32(ID);

        var result = _buildingGetAllService.GetBuildings(Id);
        return new OkObjectResult(result);
    }
}