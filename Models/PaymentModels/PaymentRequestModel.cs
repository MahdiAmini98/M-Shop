namespace M_Shop.Models.PaymentModels
{
    public class PaymentRequestModel
    {
        public int Amount { get; set; }
        public string Description { get; set; }
        public string CallbackUrl { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
    }
}
