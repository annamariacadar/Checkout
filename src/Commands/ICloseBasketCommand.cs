using Checkout.Command.Contracts;

namespace Checkout.Commands
{
    public interface ICloseBasketCommand
    {
        Task Execute(CloseBasketCommandEntry closeBasketCommandEntry);
    }
}
