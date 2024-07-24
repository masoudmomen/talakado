using Microsoft.AspNetCore;
using Dto.Payment;
using Microsoft.AspNetCore.Mvc;
using Talakado.Application.Payments;
using Talakado.Web.Utilities;
using ZarinPal.Class;
using RestSharp;
using MongoDB.Bson.IO;

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

            //return Redirect($"https://zarinpal.com/pg/StartPay/{resultZarinpalRequest.Authority}");
            return Redirect($"https://sandbox.zarinpal.com/pg/StartPay/{resultZarinpalRequest.Authority}");
        }

        public IActionResult Verify(Guid Id, string Authority)
        {
            
            string Status = HttpContext.Request.Query["Status"];
            if (Status != "" && Status.ToString().ToLower() == "ok" && Authority != "")
            {
                var payment = paymentService.GetPeyment(Id);
                if (payment == null)
                {
                    return NotFound();
                }
                int orderId = paymentService.GetOrderIdFromPaymentId(Id);
                var verification = _payment.Verification(new DtoVerification
                {
                    Amount = payment.Amount,
                    Authority = Authority,
                    MerchantId = merchendId
                }, Payment.Mode.sandbox).Result;

                #region Rest Sharp
                //var client = new RestClient("https://www.sandbox.zarinpal.com/pg/rest/WebGate/PaymentVerification.json");
                ////client.Timeout = -1;
                //var request = new RestRequest(Method.Post.ToString());
                //request.AddHeader("Content-Type", "application/json");
                //request.AddParameter("application/json", $"{{\"MerchantId\" :\"{merchendId}\",\"Authority\":\"{Authority}\",\"Amount\":\"{payment.Amount}\"}}", ParameterType.RequestBody);
                //var response = client.Execute(request);
                //VerificationPayResultDto verification= Newtonsoft.Json.JsonConvert.DeserializeObject<VerificationPayResultDto>(response.Content);
                #endregion

                if (verification.Status == 100) 
                {
                   bool verifyResult =  paymentService.VerifyPayment(Id,Authority,verification.RefId);     
                    if (verifyResult)
                    {
                        //return Redirect("/customers/order/"+orderId);
                        return RedirectToAction("Index", "Order", new { Area = "customers" });

                    }
                    TempData["message"] = $"پرداخت انجام شد ولی ثبت نشد شناسه سفارش شما {orderId} می باشد لطفا این شناسه را به مسئول فروشگاه داده و پیگیری نمایید"; 
                    return RedirectToAction("Checkout", "basket");
                }
                else
                {
                    TempData["message"] = "پرداخت انجام نشد جهت تلاش مجدد بازگشت به صفحه سفارش و پرداخت را کلیک کنید";
                    return RedirectToAction("Checkout", "basket");
                }
            }
            TempData["message"] = "اعتبار سنجی از طرف بانک با شکست مواجه شد";
            return RedirectToAction("Checkout", "basket");
        }
    }

    public class VerificationPayResultDto
    {
        public int Status { get; set; }
        public long RefId { get; set; }
    }
}
