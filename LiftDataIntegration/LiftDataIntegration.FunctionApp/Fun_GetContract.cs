using LiftDataIntegration.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace LiftDataIntegration.FunctionApp;

public class Fun_GetContract
{
    private readonly ILogger<Fun_GetContract> _logger;
    private readonly IContractService _contractService;
  public Fun_GetContract(IContractService contractService,ILogger<Fun_GetContract> logger)
    {
        _logger = logger;
        _contractService= contractService;
    }

    [Function("Fun_GetContract")]
    public async Task <IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");

         int query = Convert.ToInt32(req.Query["id"]);

        var result = _contractService.GetContract(query);

        return new OkObjectResult(result);
    }
}