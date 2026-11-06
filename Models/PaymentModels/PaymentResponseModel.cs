namespace M_Shop.Models.PaymentModels
{
    public class PaymentResponseModel
    {
        public bool Success { get; set; }
        public string Authority { get; set; }
        public string Message { get; set; }
    }
}
