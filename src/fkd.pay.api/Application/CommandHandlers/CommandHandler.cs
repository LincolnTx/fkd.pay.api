using MediatR;
using fkd.pay.api.Domain.Exceptions;
using fkd.pay.api.Application.Commands;

namespace fkd.pay.api.Application.CommandHandlers
{
    public abstract class CommandHandler
    {
        protected readonly IMediator _bus;

        protected CommandHandler(IMediator bus)
        {
            _bus = bus;
        }

        protected void NotifyValidationErrors(Command message)
        {
            foreach (var error in message.GetValidationResult().Errors)
            {
                _bus.Publish(new ExceptionNotification("001", error.ErrorMessage, error.PropertyName));
            }
        }
    }
}