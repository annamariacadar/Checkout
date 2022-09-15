using Checkout.Command.Contracts;

namespace Checkout.Commands
{
    public interface ICreateBasketCommand
    {
        Task<int> Execute(CreateBasketCommandEntry createBasketCommandEntry);
    }
}
