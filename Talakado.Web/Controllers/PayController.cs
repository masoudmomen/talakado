using Microsoft.AspNetCore;
using Dto.Payment;
using Microsoft.AspNetCore.Mvc;
using Talakado.Application.Payments;
using Talakado.Web.Utilities;
using ZarinPal.Class;

namespace Talakado.Web.Controllers
{
    public class PayController : Controller
    {
        private readonly Payment _payment;
        private readonly Authority _authority;
        private readonly Transactions _transactions;

        private readonly IConfiguration configuration;
        private readonly IPaymentService paymentService;
        private readonly string merchendId;
        public PayController(IConfiguration configuration, IPaymentService paymentService)
        {
            this.configuration = configuration;
            this.paymentService = paymentService;
            merchendId = configuration["ZarinpalMerchendId"];

            var expose = new Expose();
            _payment = expose.CreatePayment();
            _authority = expose.CreateAuthority();
            _transactions = expose.CreateTransactions();
        }
        public async Task<IActionResult> Index(Guid PaymentId)
        {
            var payment = paymentService.GetPeyment(PaymentId);
            if (payment == null)
            {
                return NotFound();  
            }
            string userId = ClaimUtility.GetUserId(User);
            if (userId != payment.UserId)
            {
                return BadRequest();
            }
            string callBackUrl = Url.Action(nameof(Verify), "Pay", new { payment.Id }, protocol: Request.Scheme);
            var resultZarinpalRequest = await _payment.Request(new DtoRequest()
            {
                Amount = payment.Amount,
                CallbackUrl = callBackUrl,
                Description = payment.Description,
                Email = payment.Email,
                MerchantId = merchendId,
                Mobile = payment.PhoneNumber
            }, 
            Payment.Mode.sandbox);

            return Redirect($"https://zarinpal.com/pg/startpay/{resultZarinpalRequest.Authority}");
        }

        public IActionResult Verify()
        {
            return View();
        }
    }
}
