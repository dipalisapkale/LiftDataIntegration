using LiftDataIntegration.Data;
using LiftDataIntegration.Data.Interface;
using LiftDataIntegration.Infrastructure;
using LiftDataIntegration.Infrastructure.Interface;
using LiftDataIntegration.Service;
using LiftDataIntegration.Service.Interface;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = FunctionsApplication.CreateBuilder(args);

builder.ConfigureFunctionsWebApplication();

builder.Services
    .AddApplicationInsightsTelemetryWorkerService()
    .ConfigureFunctionsApplicationInsights();


builder.Services.AddTransient<IDataConnect, DataConnect>();
builder.Services.AddTransient<IIntegrationData, IntegrationData>();
builder.Services.AddTransient<IIntegrationService, IntegrationService>();

builder.Services.AddTransient<IBuildingData, BuildingData>();
builder.Services.AddTransient<IBuildingService, BuildingService>();

builder.Services.AddTransient<IUnitData, UnitData>();
builder.Services.AddTransient<IUnitService, UnitService>();

builder.Services.AddTransient<IContractData, ContractData>();
builder.Services.AddTransient<IContractService, ContractService>();

builder.Services.AddTransient<IUserData, UserData>();
builder.Services.AddTransient<IUserService, UserService>();


builder.Services.AddTransient<IDashboardData, DashboardData>();
builder.Services.AddTransient<IDashboardService, DashboardService>();

builder.Services.AddTransient<ILiftRunData, LiftRunData>();
builder.Services.AddTransient<ILiftRunService, LiftRunService>();


builder.Build().Run();
