using System.Threading.Tasks;
using fkd.pay.api.Data.Context;
using fkd.pay.api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace fkd.pay.api.Data.Repositories.PaymentCardRepository
{
    public class PaymentCardRepository : Repository<PaymentCard>, IPaymentCardRepository
    {
        public PaymentCardRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
        
        public async Task<PaymentCard> FindByNumber(string cardNumber)
        {
            return await _dbSet.FirstOrDefaultAsync(card => card.CardNumber == cardNumber);
        }
    }
}