using fkd.pay.api.Application.Validations;
using MediatR;

namespace fkd.pay.api.Application.Commands
{
    public class CreateNewPaymentCardCommand : Command, IRequest<Unit>
    {
        public string CardNumber { get; set; }
        public int ExpMonth { get; set; }
        public int ExpYear { get; set; }
        public string Cvv { get; set; }
        public string CardHolderName { get; set; }
       
        public override bool IsValid()
        {
            ValidationResult = new CreateNewPaymentCardValidations().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}