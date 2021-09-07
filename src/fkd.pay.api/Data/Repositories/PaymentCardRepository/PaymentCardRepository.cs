using fkd.pay.api.Data.Context;
using fkd.pay.api.Domain.Entities;

namespace fkd.pay.api.Data.Repositories.PaymentCardRepository
{
    public class PaymentCardRepository : Repository<PaymentCard>, IPaymentCardRepository
    {
        public PaymentCardRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}