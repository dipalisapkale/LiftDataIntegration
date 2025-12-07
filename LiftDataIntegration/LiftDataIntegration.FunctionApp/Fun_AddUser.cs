using LiftDataIntegration.Entity.Model.Request;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using LiftDataIntegration.Service.Interface;

namespace LiftDataIntegration.FunctionApp;

public class Fun_AddUser
{
    private readonly ILogger<Fun_AddUser> _logger;
    private readonly IUserService _userService;
    public Fun_AddUser(IUserService userService,ILogger<Fun_AddUser> logger)
    {
        _logger = logger;
        _userService= userService;
    }

    [Function("Fun_AddUser")]
    public async Task <IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
    {
        try
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var Data = JsonSerializer.Deserialize<AddUserEntity>(requestBody);

            var result = _userService.AddUser(Data);
            return new OkObjectResult("Welcome to Azure Functions!");
        }
        catch (Exception ex)
        {
            return new OkObjectResult(new {status=200,message=ex.Message });
        }
    }
}