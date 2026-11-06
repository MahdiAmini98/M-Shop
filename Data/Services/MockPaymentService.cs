using M_Shop.Models.PaymentModels;

namespace M_Shop.Data.Services
{
    public interface IMockPaymentService
    {
        PaymentResponseModel PaymentRequest(int amount, string description, string callbackUrl, string email, string mobile);
        VerificationResponseModel Verification(string authority, int amount);
    }

    public class MockPaymentService : IMockPaymentService
    {
        public PaymentResponseModel PaymentRequest(int amount, string description, string callbackUrl, string email, string mobile)
        {
            // تولید authority تصادفی
            var authority = GenerateRandomAuthority();

            return new PaymentResponseModel
            {
                Success = true,
                Authority = authority,
                Message = "درخواست پرداخت با موفقیت ایجاد شد"
            };
        }

        public VerificationResponseModel Verification(string authority, int amount)
        {
            // شبیه‌سازی پرداخت موفق
            var random = new Random();
            var success = random.Next(0, 10) > 2; // 80% شانس موفقیت

            if (success)
            {
                return new VerificationResponseModel
                {
                    Success = true,
                    RefId = GenerateRandomRefId(),
                    Message = "پرداخت با موفقیت انجام شد"
                };
            }
            else
            {
                return new VerificationResponseModel
                {
                    Success = false,
                    RefId = 0,
                    Message = "پرداخت ناموفق بود"
                };
            }
        }

        private string GenerateRandomAuthority()
        {
            var random = new Random();
            return "A0000000000000000000000000000" + random.Next(100000, 999999).ToString();
        }

        private long GenerateRandomRefId()
        {
            var random = new Random();
            return long.Parse("111111111111" + random.Next(1000, 9999).ToString());
        }
    }
}
