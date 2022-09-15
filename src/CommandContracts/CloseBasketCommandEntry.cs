namespace Checkout.Command.Contracts
{
    public class CloseBasketCommandEntry
    {
        public int BasketId { get; set; }
        public bool Close { get; set; }
        public bool Payed { get; set; }
    }
}
