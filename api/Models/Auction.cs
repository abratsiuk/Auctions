namespace api.Models
{
    public class Auction
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime AuctionDate { get; set; }

        public ICollection<InitialOffer>? InitialOffers { get; set; }
        public ICollection<TradeResult>? TradeResults { get; set; }
        public ICollection<TradeProcess>? TradeProcesses { get; set; }
    }

}
