using System.Text.Json;
using LiftDataIntegration.Entity.Model.Request;
using LiftDataIntegration.Entity.Model.Response;
using LiftDataIntegration.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace LiftDataIntegration.FunctionApp;

public class Fun_AuthenticationUser
{
    private readonly ILogger<Fun_AuthenticationUser> _logger;
    private readonly IUserService _userService;
    public Fun_AuthenticationUser(IUserService userService,ILogger<Fun_AuthenticationUser> logger)
    {
        _logger = logger;
        _userService = userService;
    }

    [Function("Fun_AuthenticationUser")]
    public async Task <IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");

        
        var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        
        var body = JsonSerializer.Deserialize<UserAuthenticationRequest>(requestBody);

        var result = _userService.AuthenticateUser(body);
        return new OkObjectResult(result);
    }
}