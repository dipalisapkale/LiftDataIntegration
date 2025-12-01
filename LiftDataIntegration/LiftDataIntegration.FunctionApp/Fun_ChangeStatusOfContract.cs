using LiftDataIntegration.Entity.Model.Request;
using LiftDataIntegration.Service;
using System.Text.Json;
using LiftDataIntegration.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace LiftDataIntegration.FunctionApp;

public class Fun_ChangeStatusOfContract
{
    private readonly ILogger<Fun_ChangeStatusOfContract> _logger;
    private readonly IContractService _contractService;
   public Fun_ChangeStatusOfContract(IContractService contractService,ILogger<Fun_ChangeStatusOfContract> logger)
    {
        _logger = logger;
        _contractService= contractService;
    }

    [Function("Fun_ChangeStatusOfContract")]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        var requestbody = await new StreamReader(req.Body).ReadToEndAsync();
        var body = JsonSerializer.Deserialize<ChangeStatusOfContractEntity>(requestbody);
        var result = _contractService.ChangeStatusOfContract(body);
        return new OkObjectResult(result);
    }
}