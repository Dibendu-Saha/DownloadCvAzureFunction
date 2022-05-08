using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using PortfolioDownloadCvAzureFunction.Controllers;

namespace PortfolioDownloadCvAzureFunction
{
    public static class DownloadCv
    {
        [FunctionName("DownloadCv")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            try
            {
                FileController fc = new FileController();
                return await fc.DownloadFile();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
