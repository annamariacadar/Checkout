using Checkout.Command.Contracts;
using Checkout.Repository;

namespace Checkout.Commands
{
    public class CloseBasketCommand : ICloseBasketCommand
    {
        private readonly IBasketRepository _basketRepository;

        public CloseBasketCommand(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }
        public async Task Execute(CloseBasketCommandEntry closeBasketCommandEntry)
        {
            await _basketRepository.UpdateBasketAsync(closeBasketCommandEntry.BasketId, closeBasketCommandEntry.Close, closeBasketCommandEntry.Payed);
        }
    }
}
