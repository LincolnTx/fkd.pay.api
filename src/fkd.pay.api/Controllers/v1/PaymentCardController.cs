using MediatR;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using fkd.pay.api.Domain.Exceptions;
using fkd.pay.api.Application.Commands;

namespace fkd.pay.api.Controllers.v1
{
    public class PaymentCardController : BaseController
    {
        private readonly IMediator _bus;
        
        public PaymentCardController(INotificationHandler<ExceptionNotification> notifications, IMediator bus) : base(notifications)
        {
            _bus = bus;
        }

        [HttpPost]
        [ProducesResponseType((int) HttpStatusCode.NoContent)]
        public async Task<IActionResult> CreatePaymentCard([FromBody] CreateNewPaymentCardCommand command)
        {
            var response = await _bus.Send(command);

            return Response(NoContent());
        }
    }
}