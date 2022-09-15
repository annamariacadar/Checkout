namespace Checkout.Command.Contracts
{
    public class AddArticleCommandEntry
    {
        public string Item { get; set; }
        public double Price { get; set; }
        public int BasketId { get; set; }
    }
}
