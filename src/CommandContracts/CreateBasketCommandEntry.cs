namespace Checkout.Command.Contracts
{
    public class CreateBasketCommandEntry
    {
        public string Customer { get; set; }
        public bool PaysVAT { get; set; }
    }
}
