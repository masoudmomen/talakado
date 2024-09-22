using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Runtime.CompilerServices;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Talakado.StaticFilesEndPoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IHostingEnvironment _environment;

        public ImagesController(IHostingEnvironment hostingEnvironment) {
            _environment = hostingEnvironment;
        }
        
        public IActionResult Post(IFormFileCollection files, string apiKey)
        {
            if (apiKey != "mySecretKey")
            {
                return BadRequest();
            }
            try
                {
                //var files = file;
                var folderName = Path.Combine("Resource", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (files != null)
                {
                    //Upload
                    return Ok(UploadImage(files));
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal Server Error");
                throw new Exception("upload image error", ex);
            }
        }
        
        private UploadDto UploadImage(IFormFileCollection files)
        {
            string newName = Guid.NewGuid().ToString();
            var date = DateTime.Now;
            string folder = $@"Resources\images\{date.Year}-{date.Month}\";
            string folderWebAdrress = $@"Resources/images/{date.Year}-{date.Month}/";
            var uploadsRootFolder = Path.Combine(_environment.WebRootPath, folder);
            if (!Directory.Exists(uploadsRootFolder))
            {
                Directory.CreateDirectory(uploadsRootFolder);
            }
            List<string> address = new List<string>();
            foreach (var file in files)
            {
                if (file != null && file.Length > 0)
                {
                    string fileName = newName + file.FileName;
                    var filePath = Path.Combine(uploadsRootFolder, fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    address.Add(folderWebAdrress + fileName);
                }
            }
            return new UploadDto()
            {
                FileNameAddress = address,
                Status = true,
            };
        }

    }

    public class UploadDto
    {
        public bool Status { get; set; } = false;
        public List<string> FileNameAddress { get; set; }
    }
}
