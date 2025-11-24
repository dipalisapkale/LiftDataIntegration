using System.Security.Cryptography.Xml;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace LiftDataIntegration.FunctionApp;

public class Fun_Employees
{
    private readonly ILogger<Fun_Employees> _logger;

    public Fun_Employees(ILogger<Fun_Employees> logger)
    {
        _logger = logger;
    }

    [Function("GetEmployees")]
    public IActionResult GetEmployees([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");

        var employees = new List<string>() { "neil", "harshu" };



        return new OkObjectResult(employees);
    }
}