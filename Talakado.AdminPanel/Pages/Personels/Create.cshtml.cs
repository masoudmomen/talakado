using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Talakado.Application.ContentManager;
using Talakado.Infrastructure.ExternalApi.ImageServer;

namespace Talakado.AdminPanel.Pages.Personels
{
    public class CreateModel : PageModel
    {
        private readonly IImageUploadService imageUploadService;
        private readonly IPersonelManager personelManager;

        public CreateModel(IImageUploadService imageUploadService, IPersonelManager personelManager)
        {
            this.imageUploadService = imageUploadService;
            this.personelManager = personelManager;
        }

        public IFormFile File { get; set; }

        public void OnGet()
        {
            TempData["Page"] = 10;
        }

        public async Task<IActionResult> OnPostAddPerson()
        {
            if (File != null) File = null;
            File = (IFormFile)Request.Form.Files[0];
            if (File != null)
            {
                var result = await imageUploadService.UploadAsync(File);
                if (result != null && result.FileNameAddress.Count > 0)
                {
                    var person = personelManager.AddPersonel(new PersonelDto
                    {
                        Name = (!string.IsNullOrEmpty(Request.Form["name"])) ? Request.Form["name"].ToString() : "خالی",
                        Job = (!string.IsNullOrEmpty(Request.Form["job"]))? Request.Form["job"].ToString():"خالی",
                        IsShowAsOurTeam = (!string.IsNullOrEmpty(Request.Form["isShow"]) && Request.Form["isShow"] == "true")? true : false,
                        Description = (!string.IsNullOrEmpty(Request.Form["description"]))? Request.Form["description"].ToString() : "خالی",
                        ImageAddress = result.FileNameAddress[0].ToString(),
                    });
                    if (person != null) return Content("true");
                }
                return Content("false");
            }
            return Content("false");
        }
    }
    public class UploadDto
    {
        public string Message { get; set; }
        public bool Status { get; set; } = true;
        public List<string> FileNameAddress { get; set; }
    }
}
