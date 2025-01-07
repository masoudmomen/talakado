using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Talakado.Application.ContentManager;
using Talakado.Infrastructure.ExternalApi.ImageServer;

namespace Talakado.AdminPanel.Pages.Personels
{
    public class IndexModel : PageModel
    {
        private readonly IImageUploadService imageUploadService;
        private readonly IPersonelManager personelManager;

        public IndexModel(IImageUploadService imageUploadService, IPersonelManager personelManager)
        {
            this.imageUploadService = imageUploadService;
            this.personelManager = personelManager;
        }
        [BindProperty]
        public List<PersonelDto>? Personels { get; set; }
        public IFormFile File { get; set; }
        public void OnGet()
        {
            Personels = personelManager.GetPersonelsList();         
            TempData["Page"] = 11;
        }

        public async Task<IActionResult> OnPostEditPersonel()
        {
            if (File != null) File = null;
            if (Request.Form.Files.Any())
            {
                File = (IFormFile)Request.Form.Files[0];
            }
            
            var imageAddress = "";
            if (File != null)
            {
                var result = await imageUploadService.UploadAsync(File);
                if (result != null && result.FileNameAddress.Count > 0)
                {
                    imageAddress = result.FileNameAddress[0].ToString();
                }
            }
            var person = personelManager.EditPersonel(new PersonelDto
            {
                Id = (!string.IsNullOrEmpty(Request.Form["Id"])) ? int.Parse(Request.Form["Id"].ToString()) : 0,
                Name = (!string.IsNullOrEmpty(Request.Form["Name"])) ? Request.Form["Name"].ToString() : "خالی",
                Job = (!string.IsNullOrEmpty(Request.Form["Job"])) ? Request.Form["Job"].ToString() : "خالی",
                IsShowAsOurTeam = (!string.IsNullOrEmpty(Request.Form["IsShow"]) && Request.Form["IsShow"] == "true") ? true : false,
                Description = (!string.IsNullOrEmpty(Request.Form["Description"])) ? Request.Form["Description"].ToString() : "خالی",
                ImageAddress = imageAddress,
            });
            if (person != null) return Content("true");
            return Content("false");
        }

        public IActionResult OnPostDeletePersonel(string id)
        {
            if (string.IsNullOrEmpty(id)) return Content("false");
            if(personelManager.DeletePersonel(int.Parse(id))) return Content("true");
            return Content("false");
        }
    }
}
