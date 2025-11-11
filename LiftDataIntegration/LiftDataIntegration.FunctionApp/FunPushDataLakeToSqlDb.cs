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
    public FunPushDataLakeToSqlDb(IIntegrationService integrationService , ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<FunPushDataLakeToSqlDb>();
        _integrationService = integrationService;
    }

    [Function("FunPushDataLakeToSqlDb")]
    public async Task Run([TimerTrigger("0 */5 * * * *")] TimerInfo myTimer)
    {

        try
        {
            string storageAccountName = "storageaccountdatalake18";
            string fileSystemName = "mycontainer";
            string filePath = "integrationfiles/unitbuildingcontract_filled.xlsx";            
            var serviceUri = new Uri($"https://{storageAccountName}.dfs.core.windows.net");

            
            var client = new DataLakeServiceClient(serviceUri, new DefaultAzureCredential());
            var fileSystemClient = client.GetFileSystemClient(fileSystemName);
            var fileClient = fileSystemClient.GetFileClient(filePath);


            var downloadResponse = await fileClient.ReadAsync();
            using var stream = downloadResponse.Value.Content;
            using var memoryStream = new MemoryStream();
            await stream.CopyToAsync(memoryStream);
            memoryStream.Position = 0;

            using var workbook = new XLWorkbook(memoryStream);
            var worksheet = workbook.Worksheet(1);

            var result = _integrationService.SaveIntegrationService(worksheet);
        }
        catch (Exception ex)
        {

            throw ex;
        }

    }
}