using Checkout.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.Repository
{
    public interface IBasketRepository
    {
        Task<int> AddBasketEntryAsync(Basket entityToAdd);
        Task UpdateBasketAsync(int entityId, Article article);
        Task UpdateBasketAsync(int entityId, bool close, bool payed);
        Task<Basket> GetBasketAsync(int basketid);
    }
}
