using fkd.pay.api.Domain.Exceptions;
using fkd.pay.api.Domain.SeedWork;

namespace fkd.pay.api.Domain.Entities
{
    public class PaymentCard : Entity
    {
        private const decimal InitialBalance= (decimal)10.000;
        private string _cardNumber;
        public string CardName => CardNumberFix();
        private int _expMonth;
        public int ExpMonth => _expMonth;
        private int _expYear;
        public int ExpYear => _expYear;
        private string _cvv;
        private string _cardHolderName;
        public string CardHolderName => _cardHolderName;
        private decimal _availableBalance;
        public decimal AvailableBalance => _availableBalance;
        
        // TODO: fazer o saldo resetar todo dia X escolhido pelo usuário


        public PaymentCard(string cardNumber, int expMonth, int expYear, string cvv, string cardHolderName)
        {
            _cardNumber = cardNumber;
            _expMonth = expMonth;
            _expYear = expYear;
            _cvv = cvv;
            _cardHolderName = cardHolderName;
            _availableBalance = InitialBalance;
        }
        private string CardNumberFix()
        {
            return _cardNumber.Substring(_cardNumber.Length - 4);
        }

        public void DeduceValueOnBalance(decimal value)
        {
            if (_availableBalance < value)
            {
                throw new PaymentDomainException("Saldo insuficiente para essa compra");
            }
            
            _availableBalance -= value;
        }
    }
}