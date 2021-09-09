using fkd.pay.api.Application.Validations;
using MediatR;

namespace fkd.pay.api.Application.Commands
{
    public class NewPurchaseCommand : Command, IRequest<bool>
    {
        public string CardNumber { get; set; }
        public decimal PurchaseValue { get; set; }
        
        
        public override bool IsValid()
        {
            ValidationResult = new NewPurchaseCommandValidations().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}