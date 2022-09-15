using Checkout.Command.Contracts;
using Checkout.Repository;
using Checkout.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.Commands
{
    public class AddArticleCommand : IAddArticleCommand
    {
        private readonly IBasketRepository _basketRepository;

        public AddArticleCommand(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }
        public async Task Execute(AddArticleCommandEntry addArticleCommandEntry)
        {
            var article = new Article() { Item = addArticleCommandEntry.Item, Price = addArticleCommandEntry.Price };

            await _basketRepository.UpdateBasketAsync(addArticleCommandEntry.BasketId, article);
        }
    }
}
