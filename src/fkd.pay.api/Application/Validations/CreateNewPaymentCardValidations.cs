using System;
using FluentValidation;
using CreditCardValidator;
using FluentValidation.Results;
using fkd.pay.api.Application.Commands;

namespace fkd.pay.api.Application.Validations
{
    public class CreateNewPaymentCardValidations : AbstractValidator<CreateNewPaymentCardCommand>
    {
        public CreateNewPaymentCardValidations()
        {
            ValidateCardNumber();
            ValidateExpTime();
            ValidateCvv();
            ValidateCardHolderName();
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

        private void ValidateExpTime()
        {
            RuleFor(card => card.ExpYear)
                .GreaterThanOrEqualTo(DateTime.Now.Year)
                .NotEmpty()
                .WithMessage($"Exp time is required and year must be full value like => {DateTime.Now.Year}")
                .WithErrorCode("003");
        }
        
        private void ValidateCvv()
        {
            RuleFor(card => card.Cvv)
                .MaximumLength(3)
                .MinimumLength(3)
                .NotEmpty()
                .WithMessage("Card cvv is required and must have a length of 3")
                .WithErrorCode("004");
        }

        private void ValidateCardHolderName()
        {
            RuleFor(card => card.CardHolderName)
                .MaximumLength(50)
                .WithMessage("Card holder name must be less than 50 chars")
                .NotEmpty()
                .WithMessage("Card holder name is required")
                .WithErrorCode("005");
        }
        
    }
}