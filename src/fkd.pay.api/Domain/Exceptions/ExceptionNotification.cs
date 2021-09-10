using fkd.pay.api.Domain.Events;

namespace fkd.pay.api.Domain.Exceptions
{
    public class ExceptionNotification : Event
    {
        public string Code { get; private set; }
        public string Message { get; private set; }
        public string ParamName { get; private set; }

        public ExceptionNotification(string code, string message, string paramName = null)
        {
            Code = code;
            Message = message;
            ParamName = paramName;
        }
    }
}