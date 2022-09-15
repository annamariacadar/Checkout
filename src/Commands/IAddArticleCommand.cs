using Checkout.Command.Contracts;

namespace Checkout.Commands
{
    public interface IAddArticleCommand
    {
        Task Execute(AddArticleCommandEntry addArticleCommandEntry);
    }
}
