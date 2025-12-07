using LiftDataIntegration.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace LiftDataIntegration.FunctionApp;

public class Fun_GetUser
{
    private readonly ILogger<Fun_GetUser> _logger;
    private readonly IUserService _userService;
    public Fun_GetUser(IUserService userService,ILogger<Fun_GetUser> logger)
    {
        _logger = logger;
        _userService=userService;
    }

    [Function("Fun_GetUser")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
    {
        try {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            int query = Convert.ToInt32(req.Query["id"]);
            var result = _userService.GetUser(query);
            return new OkObjectResult(result);
        }
        catch (Exception ex)
        {
            return new OkObjectResult(new {status=200,ex.Message});

        }
        } 
    }
