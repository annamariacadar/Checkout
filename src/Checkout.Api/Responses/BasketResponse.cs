namespace Checkout.Api.Responses
{
    public class BasketResponse
    {
        public BasketResponse()
        {
            Articles = Enumerable.Empty<ArticleResponse>();
        }
        public int Id { get; set; }
        public IEnumerable<ArticleResponse> Articles { get; set; }
        public double TotalNet { get; set; }
        public double TotalGross { get; set; }

        public bool Close { get; set; }
        public bool Payed { get; set; }
        public string Customer { get; set; }
        public bool PaysVat { get; set; }
    }
}
