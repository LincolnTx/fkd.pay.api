using MediatR;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using fkd.pay.api.Domain.Exceptions;
using fkd.pay.api.Application.Commands;
using fkd.pay.api.Application.DTOs;
using fkd.pay.api.Application.Queries;
using fkd.pay.api.Controllers.ResponseDtos;

namespace fkd.pay.api.Controllers.v1
{
    public class PaymentCardController : BaseController
    {
        private readonly IMediator _bus;
        
        public PaymentCardController(INotificationHandler<ExceptionNotification> notifications, IMediator bus) : base(notifications)
        {
            _bus = bus;
        }

        [HttpPost("payment-card")]
        [ProducesResponseType((int) HttpStatusCode.NoContent)]
        public async Task<IActionResult> CreatePaymentCard([FromBody] CreateNewPaymentCardCommand command)
        {
            var response = await _bus.Send(command);

            return Response(NoContent());
        }
        
        [HttpPost("purchase")]
        [ProducesResponseType((int) HttpStatusCode.NoContent)]
        public async Task<IActionResult> MakePurchase([FromBody] NewPurchaseCommand command)
        {
            var response = await _bus.Send(command);

            return Response(NoContent());
        }
        
        [HttpGet("check-balance")]
        [ProducesResponseType(typeof(GetCardBalanceDto),(int) HttpStatusCode.OK)]
        public async Task<IActionResult> CheckBalance([FromQuery] string cardNumber)
        {
            var query = new GetCardBalanceQuery(cardNumber);
            var response = await _bus.Send(query);

            return Response(Ok(new BaseResponseDto<GetCardBalanceDto>(true, response)));
        }
    }
}