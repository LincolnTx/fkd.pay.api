using MediatR;
using fkd.pay.api.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using fkd.pay.api.Domain.Exceptions;

namespace fkd.pay.api.Controllers
{
    [Route("payment/[controller]")]
    [ServiceFilter(typeof(GlobalExceptionFilterAttribute))]
    public class BaseController : Controller
    {
        private readonly ExceptionNotificationHandler _notifications;

        protected IEnumerable<ExceptionNotification> Notifications => _notifications.GetNotifications();

        protected BaseController(INotificationHandler<ExceptionNotification> notifications)
        {
            _notifications = (ExceptionNotificationHandler) notifications;
        }

        protected bool IsValidOperation()
        {
            return (!_notifications.HasNotifications());
        }

        protected new IActionResult Response(IActionResult action)
        {
            if (IsValidOperation())
            {
                return action;
            }

            return BadRequest
            (
                new
                {
                    success = false,
                    errors = _notifications.GetNotifications()
                }
            );
        }
    }
}