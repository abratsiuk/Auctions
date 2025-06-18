namespace api.Models
{
    public class Buyer
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;

        public ICollection<TradeResult>? TradeResults { get; set; }
        public ICollection<TradeProcess>? TradeProcesses { get; set; }
    }

}
