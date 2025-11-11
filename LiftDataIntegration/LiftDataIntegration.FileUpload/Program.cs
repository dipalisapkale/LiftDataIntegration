using System;
using System.IO;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using Azure.Storage.Files.DataLake;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace LiftDataIntegration.FileUpload
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Load config values
            IConfiguration config = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddEnvironmentVariables()
               .AddCommandLine(args)
               .Build();

            try
            {
                // Azure Data Lake info
                string storageAccountName = "storageaccountdatalake18"; // e.g. mystorageacct
                string fileSystemName = "mycontainer"; // container name
                string folderName = "integrationfiles"; // folder inside container (optional)
                                                        //string localFilePath = @"C:\DataLakeFile\unitbuildingcontract_filled.xlsx"; // local Excel file
                string localFolderPath = @"C:\DataLakeFile"; // local Excel file

                // Build service URI
                var serviceUri = new Uri($"https://{storageAccountName}.dfs.core.windows.net");

                // Authenticate - works locally (az login) and in Azure (managed identity)
                var credential = new DefaultAzureCredential();
                var serviceClient = new DataLakeServiceClient(serviceUri, credential);

                // Get file system (container)
                var fileSystemClient = serviceClient.GetFileSystemClient(fileSystemName);
                await fileSystemClient.CreateIfNotExistsAsync();

                // Create folder if not exists
                var directoryClient = fileSystemClient.GetDirectoryClient(folderName);
                await directoryClient.CreateIfNotExistsAsync();

                string[] files = Directory.GetFiles(localFolderPath);

                foreach (string filePath in files)
                {
                    // Get file name from local path
                    string fileName = Path.GetFileName(filePath);

                    // Get file client
                    var fileClient = directoryClient.GetFileClient(fileName);

                    Console.WriteLine($"Uploading {fileName} to Data Lake...");

                    // Upload file (overwrite if exists)
                    using (FileStream fileStream = File.OpenRead(filePath))
                    {
                        await fileClient.UploadAsync(fileStream, overwrite: true);
                    }

                    Console.WriteLine($"✅ Uploaded: {fileName}");
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

            Console.WriteLine("File uploaded successfully to Data Lake!");
        }
    }
}