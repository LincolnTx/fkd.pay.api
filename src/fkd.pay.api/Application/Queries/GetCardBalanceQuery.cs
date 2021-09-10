using MediatR;
using fkd.pay.api.Application.DTOs;

namespace fkd.pay.api.Application.Queries
{
    public class GetCardBalanceQuery : IRequest<GetCardBalanceDto>
    {
        public string CardNumber { get; set; }

        public GetCardBalanceQuery(string cardNumber)
        {
            CardNumber = cardNumber;
        }
    }
}