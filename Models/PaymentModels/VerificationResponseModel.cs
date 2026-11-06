namespace M_Shop.Models.PaymentModels
{
    public class VerificationResponseModel
    {
        public bool Success { get; set; }
        public long RefId { get; set; }
        public string Message { get; set; }
    }
}
