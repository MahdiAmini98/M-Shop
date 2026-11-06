using M_Shop.Data;
using M_Shop.Data.Services;
using M_Shop.Models.PaymentModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace M_Shop.Controllers
{
    [Authorize]
    public class PaymentController : Controller
    {
        private readonly MShop_DBContext _context;
        private readonly IMockPaymentService _paymentService;

        public PaymentController(MShop_DBContext context, IMockPaymentService paymentService)
        {
            _context = context;
            _paymentService = paymentService;
        }

        #region Payment
        [Authorize]
        public IActionResult Payment()
        {
            int userid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var order = _context.Orders
                .Include(o => o.OrderDetails)
                .FirstOrDefault(u => u.UserId == userid && !u.IsFinaly);

            if (order == null)
                return NotFound();

            var amount = (int)order.OrderDetails.Sum(c => c.Price);
            var description = $"پرداخت فاکتور شماره {order.OrderId}";

            var paymentResponse = _paymentService.PaymentRequest(
                amount,
                description,
                Url.Action("OnlinePayment", "Payment", new { id = order.OrderId }, Request.Scheme),
                "Iman@Madaeny.com",
                "09197070750"
            );

            if (paymentResponse.Success)
            {
                // انتقال به درگاه بانک تستی
                return RedirectToAction("MockBank", "Payment", new
                {
                    orderId = order.OrderId,
                    amount = amount,
                    description = description,
                    authority = paymentResponse.Authority
                });
            }
            else
            {
                return BadRequest("خطا در ایجاد درخواست پرداخت");
            }
        }

        public IActionResult MockBank(int orderId, int amount, string description, string authority)
        {
            var model = new MockBankModel
            {
                OrderId = orderId,
                Amount = amount,
                Description = description,
                Authority = authority
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult ProcessPayment(int orderId, string authority, string cardNumber, string cvv2)
        {
            // پاک کردن خط تیره از شماره کارت
            var cleanCardNumber = cardNumber?.Replace("-", "") ?? "";

            // اعتبارسنجی ساده شماره کارت و CVV2
            if (string.IsNullOrEmpty(cleanCardNumber) || cleanCardNumber.Length != 16 || !cleanCardNumber.All(char.IsDigit))
            {
                TempData["Error"] = "شماره کارت نامعتبر است. شماره کارت باید 16 رقم باشد.";
                return RedirectToAction("MockBank", new { orderId, authority });
            }

            if (string.IsNullOrEmpty(cvv2) || cvv2.Length != 3 || !cvv2.All(char.IsDigit))
            {
                TempData["Error"] = "CVV2 نامعتبر است. CVV2 باید 3 رقم باشد.";
                return RedirectToAction("MockBank", new { orderId, authority });
            }

            // انتقال به صفحه تایید پرداخت
            return RedirectToAction("VerifyPayment", new { orderId, authority, success = true });
        }
        public IActionResult VerifyPayment(int orderId, string authority, bool success)
        {
            if (success)
            {
                // شبیه‌سازی بازگشت از درگاه بانک
                var callbackUrl = Url.Action("OnlinePayment", "Payment", new { id = orderId, status = "ok", authority }, Request.Scheme);
                return Redirect(callbackUrl);
            }
            else
            {
                TempData["Error"] = "پرداخت ناموفق بود";
                return RedirectToAction("MockBank", new { orderId, authority });
            }
        }

        public IActionResult OnlinePayment(int id, string status, string authority)
        {
            if (!string.IsNullOrEmpty(status) && status.ToLower() == "ok" && !string.IsNullOrEmpty(authority))
            {
                var order = _context.Orders
                    .Include(o => o.OrderDetails)
                    .FirstOrDefault(o => o.OrderId == id);

                if (order == null)
                    return NotFound();

                var amount = (int)order.OrderDetails.Sum(d => d.Price);
                var verification = _paymentService.Verification(authority, amount);

                if (verification.Success)
                {
                    order.IsFinaly = true;
                    _context.Orders.Update(order);
                    _context.SaveChanges();

                    ViewBag.Code = verification.RefId;
                    return View("PaymentSuccess");
                }
            }

            return View("PaymentFailed");
        }
        #endregion
    }
}
