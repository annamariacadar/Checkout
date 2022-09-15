using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.Common
{
    public class Basket
    {
        public Basket()
        {
            Articles = Enumerable.Empty<Article>();
        }
        public int Id { get; set; }
        public IEnumerable<Article> Articles { get; set; }
        public double TotalNet { get; set; }
        public double TotalGross { get; set; }

        public bool Close { get; set; }
        public bool Payed { get; set; }
        public string Customer { get; set; }
        public bool PaysVat { get; set; }
    }
}
