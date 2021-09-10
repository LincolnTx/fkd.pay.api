using System;
using MediatR;
using Dapper;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using fkd.pay.api.Application.DTOs;
using fkd.pay.api.Domain.Exceptions;
using Microsoft.Extensions.Logging;
using fkd.pay.api.Application.Queries;
using fkd.pay.api.Application.Queries.ViewModels;

namespace fkd.pay.api.Application.QueryHandlers
{
    public class GetCardBalanceQueryHandler : QueryHandler, IRequestHandler<GetCardBalanceQuery, GetCardBalanceDto>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<GetCardBalanceQueryHandler> _logger;
        private readonly IMediator _bus;

        public GetCardBalanceQueryHandler(IMapper mapper, 
            ILogger<GetCardBalanceQueryHandler> logger,
            IMediator bus)
        {
            _mapper = mapper;
            _logger = logger;
            _bus = bus;
        }

        public async Task<GetCardBalanceDto> Handle(GetCardBalanceQuery request, CancellationToken cancellationToken)
        {
            using var dbConnection = DbConnection;
            
            var sqlCommand = "SELECT p.card_number , p.card_holder_name , p.available_balance " +
                                    "FROM \"fake-pay\".payment_card p where p.card_number = @cardNumber";
            try
            {
                var data = await dbConnection.QueryFirstAsync<GetCardBalanceViewModel>(sqlCommand, new
                {
                    cardNumber = request.CardNumber
                });

                return  _mapper.Map<GetCardBalanceDto>(data);
            }
            catch (Exception e)
            {
                _logger.LogError($"Erro ao buscar cartão do banco de dados {e.Message} --- {e.InnerException}");
                await _bus.Publish(
                    new ExceptionNotification("012",
                        "Error to get card on database, very card number before try again", 
                        nameof(request.CardNumber)),
                    cancellationToken);
                return null;
            }
        }
    }
}