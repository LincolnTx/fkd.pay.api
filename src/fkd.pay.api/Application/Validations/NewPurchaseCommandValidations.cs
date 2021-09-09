using FluentValidation;
using CreditCardValidator;
using FluentValidation.Results;
using fkd.pay.api.Application.Commands;

namespace fkd.pay.api.Application.Validations
{
    public class NewPurchaseCommandValidations : AbstractValidator<NewPurchaseCommand>
    {
        public NewPurchaseCommandValidations()
        {
            ValidateCardNumber();
            ValidatePurchaseValue();
        }
        
        private void ValidateCardNumber()
        {
            RuleFor(command => command)
                .Custom((card, context) =>
                {
                    var detector = new CreditCardDetector(card.CardNumber);
                    if (detector.IsValid()) return;
                    
                    var failure = new ValidationFailure(nameof(card.CardNumber), "Cred card number is invalid")
                    {
                        ErrorCode = "001"
                    };
                        
                    context.AddFailure(failure);
                });

            RuleFor(card => card.CardNumber)
                .MaximumLength(22)
                .NotEmpty()
                .WithMessage("The cred card number is required")
                .WithErrorCode("002");
        }

        private void ValidatePurchaseValue()
        {
            RuleFor(command => command.PurchaseValue)
                .GreaterThan(0)
                .WithMessage("Purchase value must be greater than 0")
                .WithErrorCode("008")
                .NotEmpty()
                .WithMessage("Purchase value cannot be empty")
                .WithErrorCode("009");
        }
    }
}