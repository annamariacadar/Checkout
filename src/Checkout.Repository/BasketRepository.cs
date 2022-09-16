using Checkout.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Checkout.Common.Exceptions;

namespace Checkout.Repository
{
    public class BasketRepository : IBasketRepository
    {
        private readonly BasketContext _dbContext;

        public BasketRepository(BasketContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddBasketEntryAsync(Basket entityToAdd)
        {
            var result = await _dbContext.Baskets.AddAsync(entityToAdd);
            _dbContext.SaveChanges();
            return entityToAdd.Id;
        }

        public async Task<Basket> GetBasketAsync(int basketid)
        {
            var basket = await _dbContext.Baskets.Include(basket => basket.Articles).AsNoTracking().FirstOrDefaultAsync(e => e.Id == basketid);
            if (basket == null)
            {
                throw new BasketNotFoundException(basketid.ToString(), "BasketNotFound");
            }
            return basket;
        }

        public async Task UpdateBasketAsync(int entityId, Article article)
        {
            var result = _dbContext.Baskets.Where(e => e.Id == entityId).FirstOrDefault();
            result.Articles = result.Articles.Append(article).ToList();
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateBasketAsync(int entityId, bool close, bool payed)
        {
            var basket = _dbContext.Baskets.Where(e => e.Id == entityId).FirstOrDefault();

            if(basket==null)
            {
                throw new BasketNotFoundException(entityId.ToString(), "BasketNotFound");
            }

            basket.Close = close;
            basket.Payed = payed;
            await _dbContext.SaveChangesAsync();
        }
    }
}
