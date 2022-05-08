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
            var connectionStr = "DefaultEndpointsProtocol=https;AccountName=myportfoliostorageacc;AccountKey=9yuDvmq3+CFGcTRwufrk/v6Gfh9bYNmlp7ZfVcSNJhzkpX2rCysJxR/YrNbbiJTaZjMUdf5Ej1Vld4VL18n/FA==;EndpointSuffix=core.windows.net";
            var container = new BlobContainerClient(connectionStr, "app-files");

            var blob = container.GetBlobClient(fileName);

            try
            {
                var res = await blob.DownloadAsync();
                byte[] filebytes = Encoding.UTF8.GetBytes(fileName);
                return File(res.Value.Content, res.Value.ContentType, fileName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
