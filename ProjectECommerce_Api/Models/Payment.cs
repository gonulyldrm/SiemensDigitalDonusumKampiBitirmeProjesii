namespace ProjectECommerce_Api.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public PaymentOption PaymentOption { get; set; }    
        public int BasketId { get; set; }
        public Payment() { } 
        public Payment(int paymentId, PaymentOption paymentOption,int basketId)
        {
            PaymentId = paymentId;
            PaymentOption = paymentOption;
            BasketId= basketId;
        }

    }
    
}
