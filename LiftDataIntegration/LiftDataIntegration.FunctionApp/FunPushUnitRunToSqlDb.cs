//using System;
//using Azure.Identity;
//using Azure.Storage.Files.DataLake;
//using ClosedXML.Excel;
//using LiftDataIntegration.Service;
//using Microsoft.Azure.Functions.Worker;
//using Microsoft.Extensions.Logging;

//namespace LiftDataIntegration.FunctionApp;

//public class FunPushUnitRunToSqlDb
//{
//    private readonly ILogger _logger;
//    private readonly IIntegrationService _integrationService;
//    public FunPushUnitRunToSqlDb(IIntegrationService integrationService, ILoggerFactory loggerFactory)
//    {
//        _logger = loggerFactory.CreateLogger<FunPushUnitRunToSqlDb>();
//        _integrationService = integrationService;
//    }

//    [Function("FunPushUnitRunToSqlDb")]
//    public async Task Run([TimerTrigger("*/10 * * * *")] TimerInfo myTimer)
//    {
//        _logger.LogInformation("Function app trigger - FunPushDataLakeToSqlDb");

//        try
//        {
//            string storageAccountName = Environment.GetEnvironmentVariable("StorageAccountName");
//            string fileSystemName = Environment.GetEnvironmentVariable("DataLakeFileSystem");
//            string FilePath = Environment.GetEnvironmentVariable("UnitrunFilePath");
//            var ServiceUri = new Uri(Environment.GetEnvironmentVariable("serviceUri"));

//            _logger.LogInformation("Connecting with Datalake client");

//            var client = new DataLakeServiceClient(ServiceUri, new DefaultAzureCredential());
//            var fileSystemClient = client.GetFileSystemClient(fileSystemName);
//            var fileClient = fileSystemClient.GetFileClient(FilePath);

//            _logger.LogInformation("Reading data from file");
//            var downloadResponse = await fileClient.ReadAsync();
//            using var stream = downloadResponse.Value.Content;
//            using var memoryStream = new MemoryStream();
//            await stream.CopyToAsync(memoryStream);
//            memoryStream.Position = 0;

//            _logger.LogInformation("Loaded data in stream");
//            using var workbook = new XLWorkbook(memoryStream);
//            var worksheet = workbook.Worksheet(1);

//            _logger.LogInformation("Calling sql to save data");
//            var result = _integrationService.SaveRunUnitData(worksheet);
//            _logger.LogInformation("save data complete");
//        }
//        catch (Exception ex)
//        {

//            _logger.LogError("Error - " + ex.Message);
//            _logger.LogError("Error - " + ex.StackTrace);
//        }
//        _logger.LogInformation("Function app execution ended - FunPushDataLakeToSqlDb");
//    }
//}