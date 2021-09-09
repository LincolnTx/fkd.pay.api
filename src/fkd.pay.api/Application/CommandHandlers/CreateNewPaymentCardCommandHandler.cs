using MediatR;
using System.Threading;
using System.Threading.Tasks;
using fkd.pay.api.Domain.Entities;
using Microsoft.Extensions.Logging;
using fkd.pay.api.Domain.Exceptions;
using fkd.pay.api.Application.Commands;

namespace fkd.pay.api.Application.CommandHandlers
{
    public class CreateNewPaymentCardCommandHandler : CommandHandler, IRequestHandler<CreateNewPaymentCardCommand, Unit>
    {
        private readonly IPaymentCardRepository _paymentCardRepository;
        private readonly ILogger<CreateNewPaymentCardCommandHandler> _logger;
        
        public CreateNewPaymentCardCommandHandler(
            IMediator bus,
            IPaymentCardRepository paymentCardRepository, 
            ILogger<CreateNewPaymentCardCommandHandler> logger) 
            : base(bus)
        {
            _paymentCardRepository = paymentCardRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(CreateNewPaymentCardCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Unit.Value;
            }

            var paymentCard = new PaymentCard(request.CardNumber, request.ExpMonth, request.ExpYear, request.Cvv, request.CardHolderName);

            var foundCard = await _paymentCardRepository.FindByNumber(request.CardNumber);

            if (foundCard != null)
            {
                var exception = new ExceptionNotification("006", "Card number already exists");
                await _bus.Publish(exception, cancellationToken);
                
                return Unit.Value;
            }
            
            _paymentCardRepository.Add(paymentCard);

            if (!await _paymentCardRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken))
            {
                var exception = new ExceptionNotification("007", "Error when save your card data, try again later");
                await _bus.Publish(exception, cancellationToken);
                
                return Unit.Value;
            }
            
            return Unit.Value;
        }
    }
}