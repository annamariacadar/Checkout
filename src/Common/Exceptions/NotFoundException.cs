using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.Common.Exceptions
{
    public class BasketNotFoundException : Exception
    {
        public BasketNotFoundException(string basketId, string errorMessage)
                : base($"Basket {basketId} not found.")
        {
            Data.Add("basketId", basketId);
        }
    }
}
