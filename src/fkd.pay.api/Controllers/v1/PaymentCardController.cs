using MediatR;
using fkd.pay.api.Domain.Exceptions;

namespace fkd.pay.api.Controllers.v1
{
    public class PaymentCardController : BaseController
    {
        private readonly IMediator _bus;
        
        public PaymentCardController(INotificationHandler<ExceptionNotification> notifications, IMediator bus) : base(notifications)
        {
            _bus = bus;
        }
    }
}