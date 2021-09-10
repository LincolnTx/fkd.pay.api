using System;

namespace fkd.pay.api.Domain.Exceptions
{
    public class PaymentDomainException : Exception
    {
        public PaymentDomainException()
        { }

        public PaymentDomainException(string message)
            : base(message)
        { }

        public PaymentDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}