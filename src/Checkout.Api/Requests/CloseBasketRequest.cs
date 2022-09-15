namespace Checkout.Api.Requests
{
    public class CloseBasketRequest
    {
        public bool Close { get;set;}
        public bool Payed { get; set; }
    }
}
