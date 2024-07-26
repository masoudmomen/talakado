using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Talakado.Application.Discounts.AddNewDiscountService;

namespace Talakado.AdminPanel.Pages.Discounts
{
    public class CreateModel : PageModel
    {
        private readonly IAddNewDiscountService addNewDiscountService;

        public CreateModel(IAddNewDiscountService addNewDiscountService)
        {
            this.addNewDiscountService = addNewDiscountService;
        }
        public AddNewDiscountDto model { get; set; }
        public void OnGet()
        {
        }

        public void OnPost()
        {
            addNewDiscountService.Execute(model);
        }
    }
}
