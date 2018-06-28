using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Charitygame.Controllers
{
    public class BlobsController : Controller
    {
        // GET: Blobs
        public ActionResult Index()
        {
            return View();
        }

        private CloudBlobContainer GetCloudBlobContainer()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                    CloudConfigurationManager.GetSetting("tgstorestdlrsneu_AzureStorageConnectionString"));
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("selfieupload");
            return container;
        }



        public string UploadBlob(HttpPostedFileBase file)
        {
            // The code in this section goes here.
            CloudBlobContainer container = GetCloudBlobContainer();
            CloudBlockBlob blob = container.GetBlockBlobReference(file.FileName);
            var fileName = file.FileName;

            //using (var fileStream = System.IO.File.OpenRead(file.FileName))
            //{
                blob.UploadFromStream(file.InputStream);
            //}
            return "success!";
        }

        public async Task<string> GetList()
        {
            //var baseUrl = "http://sampleserver6.arcgisonline.com/arcgis/rest/services/Census/MapServer/3?f=pjson";

            var baseUrl = "http://xx.xx.xxx.xxx:3000/game_image";
            var client = new HttpClient();
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");

            

            var json = await client.GetStringAsync(baseUrl);
            //var resultObject = JsonConvert.DeserializeObject(json);

            //List<Models.Game> gm = resultObject();

            return json.ToString();
        }

    }

   
}