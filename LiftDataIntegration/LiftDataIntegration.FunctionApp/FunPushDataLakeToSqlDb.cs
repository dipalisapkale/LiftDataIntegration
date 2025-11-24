using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Azure.Identity;
using Azure.Storage.Files.DataLake;
using CsvHelper;
using LiftDataIntegration.Entity.Model;
using Microsoft.Data.SqlClient;
using System.Text;
using System.Data;
using ExcelDataReader;
using ClosedXML.Excel;
using LiftDataIntegration.Service;

namespace LiftDataIntegration.FunctionApp;

/// <summary>
/// Timer Trigger function
/// </summary>
public class FunPushDataLakeToSqlDb
{
    private readonly ILogger _logger;
    private readonly IIntegrationService _integrationService;
    public FunPushDataLakeToSqlDb(IIntegrationService integrationService, ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<FunPushDataLakeToSqlDb>();
        _integrationService = integrationService;
    }

    [Function("FunPushDataLakeToSqlDb")]
    public async Task Run([TimerTrigger("*/5 * * * *")] TimerInfo myTimer)
    {
        _logger.LogInformation("Function app trigger - FunPushDataLakeToSqlDb");

        try
        {
            string storageAccountName = Environment.GetEnvironmentVariable("StorageAccountName");
            string fileSystemName = Environment.GetEnvironmentVariable("DataLakeFileSystem");
            string filePath = Environment.GetEnvironmentVariable("UnitBuildingFilePath");
            var serviceUri = new Uri(Environment.GetEnvironmentVariable("serviceUri"));

            _logger.LogInformation("Connecting with Datalake client");

            var client = new DataLakeServiceClient(serviceUri, new DefaultAzureCredential());
            var fileSystemClient = client.GetFileSystemClient(fileSystemName);
            var fileClient = fileSystemClient.GetFileClient(filePath);

            _logger.LogInformation("Reading Data from file");

            var downloadResponse = await fileClient.ReadAsync();
            using var stream = downloadResponse.Value.Content;
            using var memoryStream = new MemoryStream();
            await stream.CopyToAsync(memoryStream);
            memoryStream.Position = 0;

            _logger.LogInformation("Loaded data stream");

            using var workbook = new XLWorkbook(memoryStream);
            var worksheet = workbook.Worksheet(1);
            _logger.LogInformation("calling sql to save data");
            var result = _integrationService.SaveIntegrationService(worksheet);
            _logger.LogInformation("Save opration completed");
        }
        catch (Exception ex)
        {
            _logger.LogError("Error - " + ex.Message);
            _logger.LogError("Error - " + ex.StackTrace);
        }

        _logger.LogInformation("Function app execution ended - FunPushDataLakeToSqlDb");

    }
}