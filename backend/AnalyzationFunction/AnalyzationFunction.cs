using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace AnalyzationFunction
{
    public static class AnalyzationFunction
    {
        [FunctionName("AnalyzationFunction")]
        public static void Run([BlobTrigger("picsin/{name}", Connection = "BlobStorageConnection")]Stream myBlob, string name, ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
        }
    }
}
