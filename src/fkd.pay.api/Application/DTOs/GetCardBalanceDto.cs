namespace fkd.pay.api.Application.DTOs
{
    public class GetCardBalanceDto
    {
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public decimal AvailableBalance { get; set; }
    }
}