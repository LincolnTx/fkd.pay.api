using fkd.pay.api.Application.DTOs;
using fkd.pay.api.Application.Queries.ViewModels;

namespace fkd.pay.api.Application.AutoMapper
{
    public class CardBalanceViewModelToCardBalanceDto : MappingProfile
    {
        public CardBalanceViewModelToCardBalanceDto()
        {
            CreateCardBalanceDto();
        }

        private void CreateCardBalanceDto()
        {
            CreateMap<GetCardBalanceViewModel, GetCardBalanceDto>()
                .ConvertUsing(src => new GetCardBalanceDto
                {
                    CardNumber = src.card_number,
                    CardHolderName = src.card_holder_name,
                    AvailableBalance = src.available_balance
                });
        }
    }
}