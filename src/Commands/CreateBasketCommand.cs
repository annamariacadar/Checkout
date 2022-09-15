using Checkout.Command.Contracts;
using Checkout.Repository;
using Checkout.Repository.Entities;

namespace Checkout.Commands
{
    public class CreateBasketCommand : ICreateBasketCommand
    {
        private readonly IBasketRepository _basketRepository;

        public CreateBasketCommand(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }
        public async Task<int> Execute(CreateBasketCommandEntry createBasketCommandEntry)
        {
            var basket = new Basket() { CustomerName = createBasketCommandEntry.Customer, PaysVat = createBasketCommandEntry.PaysVAT };

            var id = await _basketRepository.AddBasketEntryAsync(basket);

            return id;
        }
    }
}
