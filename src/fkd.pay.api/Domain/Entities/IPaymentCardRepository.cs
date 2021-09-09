using System.Threading.Tasks;
using fkd.pay.api.Domain.SeedWork;

namespace fkd.pay.api.Domain.Entities
{
    public interface IPaymentCardRepository : IRepository<PaymentCard>
    {
        Task<PaymentCard> FindByNumber(string cardNumber);
    }
}