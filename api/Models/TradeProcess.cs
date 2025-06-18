namespace api.Models
{
    public class TradeProcess
    {
        public long Id { get; set; }

        public long AuctionId { get; set; }
        public Auction Auction { get; set; } = null!;

        public long ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public long BuyerId { get; set; }
        public Buyer Buyer { get; set; } = null!;

        public decimal OfferedPrice { get; set; }
        public DateTime OfferedAt { get; set; }
        public bool IsWinningOffer { get; set; }
    }

}
