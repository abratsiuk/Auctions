namespace api.Models
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string Category { get; set; } = null!;
        public string? Subcategory { get; set; }

        public ICollection<InitialOffer>? InitialOffers { get; set; }
        public ICollection<TradeResult>? TradeResults { get; set; }
        public ICollection<TradeProcess>? TradeProcesses { get; set; }
    }

}
