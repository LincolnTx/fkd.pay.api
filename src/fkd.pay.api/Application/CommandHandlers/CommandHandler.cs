using System.Threading.Tasks;
using fkd.pay.api.Application.Commands;
using fkd.pay.api.Domain.Exceptions;
using fkd.pay.api.Domain.SeedWork;
using MediatR;

namespace fkd.pay.api.Application.CommandHandlers
{
    public abstract class CommandHandler
    {
        protected readonly IMediator _bus;
        private readonly ExceptionNotificationHandler _notifications;

        protected CommandHandler(IMediator bus, INotificationHandler<ExceptionNotification> notifications)
        {
            _bus = bus;
            _notifications = (ExceptionNotificationHandler)notifications;
        }

        protected void NotifyValidationErrors(Command message)
        {
            foreach (var error in message.GetValidationResult().Errors)
            {
                _bus.Publish(new ExceptionNotification("001", error.ErrorMessage, error.PropertyName));
            }
        }

        // public async Task<bool> Commit()
        // {
        //     if (_notifications.HasNotifications()) return false;
        //     if (await _uow.Commit()) return true;
        //
        //     await _bus.Publish(new ExceptionNotification("002", "We had a problem during saving your data."));
        //
        //     return false;
        // }
    }
}