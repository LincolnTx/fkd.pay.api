using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using fkd.pay.api.Domain.Entities;
using Microsoft.Extensions.Logging;
using fkd.pay.api.Domain.Exceptions;
using fkd.pay.api.Application.Commands;

namespace fkd.pay.api.Application.CommandHandlers
{
    public class NewPurchaseCommandHandler : CommandHandler, IRequestHandler<NewPurchaseCommand, bool>
    {
        private readonly IPaymentCardRepository _paymentCardRepository;
        private readonly ILogger<NewPurchaseCommandHandler> _logger;
        
        public NewPurchaseCommandHandler(IMediator bus, 
            IPaymentCardRepository paymentCardRepository, 
            ILogger<NewPurchaseCommandHandler> logger) : base(bus)
        {
            _paymentCardRepository = paymentCardRepository;
            _logger = logger;
        }

        public async Task<bool> Handle(NewPurchaseCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return false;
            }

            var card = await _paymentCardRepository.FindByNumber(request.CardNumber);

            if (card == null)
            {
                var exception = new ExceptionNotification("010", "Card number doesn't exist");
                await _bus.Publish(exception, cancellationToken);

                return false;
            }

            try
            {
                card.DeduceValueOnBalance(request.PurchaseValue);

                if (await _paymentCardRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken))
                {
                    return true;
                }
            
                var saveException = new ExceptionNotification("007", "Error when save your card data, try again later");
                await _bus.Publish(saveException, cancellationToken);

                return false;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error on purchase, value was greater thane card balance");
                var balanceException = new ExceptionNotification("011", "Insufficient funds to complete purchase");
                await _bus.Publish(balanceException, cancellationToken);
                return false;
            }
            
        }
    }
}