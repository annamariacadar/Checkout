using Checkout.Common;
using Checkout.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.Application.Query
{
    public interface IBasketApplication
    {
       Task<Basket> GetBasketAsync(int basketId);
    }
}
