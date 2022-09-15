using Checkout.Api.Requests;
using FluentValidation;

namespace Checkout.Api.Validators
{
    public sealed class BasketRequestValidator : AbstractValidator<BasketRequest>
    {
        public BasketRequestValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(m => m.Customer).NotNull().NotEmpty().WithMessage("Customer is required");

            RuleFor(m => m.PaysVat).NotNull().WithMessage("PaysVat is required");
        }
    }
}
