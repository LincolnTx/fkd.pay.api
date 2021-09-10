namespace fkd.pay.api.Application.Queries.ViewModels
{
    public class GetCardBalanceViewModel
    {
        public string card_number { get; set; }
        public string card_holder_name { get; set; }
        public decimal available_balance { get; set; }
    }
}