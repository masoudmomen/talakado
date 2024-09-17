using Amazon.Runtime.EventStreams;
using Microsoft.AspNetCore.Http;
using MongoDB.Bson.IO;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZstdSharp.Unsafe;

namespace Talakado.Infrastructure.ExternalApi.ImageServer
{
    public interface IImageUploadService
    {
        List<string> Upload(List<IFormFile> files);
        List<string>? UploadSingleImage(IFormFile file);
        //UploadDto UploadFile(IFormFile file);
    }

    public class ImageUploadService : IImageUploadService
    {
        public UploadDto Upload(List<IFormFile> files)
        {
            try
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

                UploadDto upload = Newtonsoft.Json.JsonConvert.DeserializeObject<UploadDto>(response.Content);
                return upload;
            }
            catch (Exception e)
            {

                return new UploadDto
                {
                    Status = false,
                    Message = e.InnerException.ToString() + e.Message
                };
            }
        }

        //[Obsolete]
        public List<string>? UploadSingleImage(IFormFile file)
        {
            var options = new RestClientOptions()
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("https://localhost:7238/api/Images?apikey=mySecretKey", Method.Post);
            request.AlwaysMultipartFormData = true;
            if (file != null)
            {
                byte[] bytes;
                using (var ms = new MemoryStream())
                {
                    file.CopyToAsync(ms);
                    bytes = ms.ToArray();
                }
                request.AddFile(file.FileName, bytes, file.FileName, file.ContentType);
            }
            RestResponse response = client.Execute(request);
            if (response.Content !=null)
            {
                var upload = new UploadDto();
                upload = Newtonsoft.Json.JsonConvert.DeserializeObject<UploadDto>(response.Content);

                client.Dispose();

                if (upload != null) { return upload.FileNameAddress; }
            }
            return null;
        }

        List<string> IImageUploadService.Upload(List<IFormFile> files)
        {
            throw new NotImplementedException();
        }


        //public UploadDto UploadFile(IFormFile file)
        //{

        //}
    }
    public class UploadDto
    {
        public string Message { get; set; }
        public bool Status { get; set; } = true;
        public List<string> FileNameAddress { get; set; }
    }

}
