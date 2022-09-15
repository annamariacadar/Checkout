using Checkout.Common;
using Checkout.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.Application.Query
{
    public class BasketApplication : IBasketApplication
    {
        private readonly IBasketRepository _basketRepository;
        private const int VAT = 10;

        public BasketApplication(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }
        public async Task<Basket> GetBasketAsync(int basketId)
        {
            var basketEntity = await _basketRepository.GetBasketAsync(basketId);

            var basket = new Basket()
            {
                Id = basketEntity.Id,
                Articles = basketEntity.Articles.Select(e => new Article() { Id = e.Id, Price = e.Price, Item = e.Item }).AsEnumerable(),
                Customer = basketEntity.CustomerName,
                Payed = basketEntity.Payed,
                PaysVat = basketEntity.PaysVat,
                Close = basketEntity.Close,
                TotalGross = basketEntity.Articles.Sum(e => e.Price + e.Price / VAT),
                TotalNet = basketEntity.Articles.Sum(e => e.Price)
            };

            return basket;
        }
    }
}