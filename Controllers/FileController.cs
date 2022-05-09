using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioDownloadCvAzureFunction.Controllers
{
    class FileController : ControllerBase
    {
        public async Task<FileResult> DownloadFile()
        {
            string fileName = "CV_Dibendu_Saha.pdf";
            var connectionStr = System.Environment.GetEnvironmentVariable("AzureWebJobsStorage");
            var container = new BlobContainerClient(connectionStr, "app-files");

            var blob = container.GetBlobClient(fileName);

            try
            {
                var res = await blob.DownloadAsync();
                return File(res.Value.Content, res.Value.ContentType, fileName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
