namespace Checkout.Api.Requests
{
    public class BasketRequest
    {
        public string Customer { get; set; }
        public bool PaysVat { get; set; }
    }
}
