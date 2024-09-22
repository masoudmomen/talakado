using Amazon.Runtime.EventStreams;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using MongoDB.Bson.IO;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ZstdSharp.Unsafe;
using static System.Net.WebRequestMethods;

namespace Talakado.Infrastructure.ExternalApi.ImageServer
{
    public interface IImageUploadService
    {
        List<string> Upload(List<IFormFile> files);
        Task<UploadDto> UploadAsync(IFormFile file);
        Task<UploadDto> UploadMultipleAsync(List<IFormFile> files);
    }

    public class ImageUploadService : IImageUploadService
    {
        private readonly HttpClient httpClient;
        public ImageUploadService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        

        public async Task<UploadDto> UploadAsync(IFormFile file)
        {
            var req = new HttpRequestMessage();
            req.Method = HttpMethod.Post;
            // you might need to update the uri 
            req.RequestUri = new Uri("https://localhost:7238/api/Images?apikey=mySecretKey");
            HttpResponseMessage resp = null;
            using (var fs = file.OpenReadStream())
            {
                var form = new MultipartFormDataContent();

                var imageStream = new StreamContent(fs);
                imageStream.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);
                // because your WebAPI expects a field named as `file`
                form.Add(imageStream, "files", file.FileName);
                req.Content = form;
                resp = await this.httpClient.SendAsync(req);
            }
            return Newtonsoft.Json.JsonConvert.DeserializeObject<UploadDto>(await resp.Content.ReadAsStringAsync());
        }


        public async Task<UploadDto> UploadMultipleAsync(List<IFormFile> files)
        {
            var file = files[0];
            var req = new HttpRequestMessage();
            req.Method = HttpMethod.Post;
            // you might need to update the uri 
            req.RequestUri = new Uri("https://localhost:7238/api/Images?apikey=mySecretKey");
            HttpResponseMessage resp = null;
            using (var fs = file.OpenReadStream())
            {
                var form = new MultipartFormDataContent();

                var imageStream = new StreamContent(fs);
                imageStream.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);
                // because your WebAPI expects a field named as `file`
                form.Add(imageStream, "files", file.FileName);
                req.Content = form;
                resp = await this.httpClient.SendAsync(req);
            }
            return Newtonsoft.Json.JsonConvert.DeserializeObject<UploadDto>(await resp.Content.ReadAsStringAsync());
        }


        public List<string> Upload(List<IFormFile> files)
        {
            var options = new RestClientOptions()
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("https://localhost:7238/api/Images?apikey=mySecretKey", Method.Post);
            request.AlwaysMultipartFormData = true;
            foreach (var item in files)
            {
                byte[] bytes;
                using (var ms = new MemoryStream())
                {
                    item.CopyToAsync(ms);
                    bytes = ms.ToArray();
                }
                request.AddFile(item.FileName, bytes, item.FileName, item.ContentType);
            }
            RestResponse response = client.Execute(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(response.Content);
        }
    }
    public class UploadDto
    {
        public string Message { get; set; }
        public bool Status { get; set; } = true;
        public List<string> FileNameAddress { get; set; }
    }

}








//var file = files[0];
//var req = new HttpRequestMessage();
//req.Method = HttpMethod.Post;
//// you might need to update the uri 
//req.RequestUri = new Uri("https://localhost:7238/api/Images?apikey=mySecretKey");
//HttpResponseMessage resp = null;
//using (var fs = file.OpenReadStream())
//{
//    var form = new MultipartFormDataContent();

//    var imageStream = new StreamContent(fs);
//    imageStream.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);
//    // because your WebAPI expects a field named as `file`
//    form.Add(imageStream, "files", file.FileName);
//    req.Content = form;
//    resp = await this.httpClient.SendAsync(req);
//}
//return Newtonsoft.Json.JsonConvert.DeserializeObject<UploadDto>(await resp.Content.ReadAsStringAsync());