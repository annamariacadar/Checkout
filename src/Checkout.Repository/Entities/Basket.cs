using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Checkout.Repository.Entities
{
    public class Basket
    {
        public Basket()
        {
            Articles = new List<Article>();
            Close=false;
            Payed=false;
        }

        public int Id { get; set; }
        public IList<Article> Articles {get;set; }
        public bool Close { get; set; }
        public bool Payed { get; set; }
        public string CustomerName { get; set; }
        public bool PaysVat { get; set; }
    }
}
