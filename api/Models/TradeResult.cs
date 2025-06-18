namespace api.Models
{
    public class TradeResult
    {
        public long Id { get; set; }

        public long AuctionId { get; set; }
        public Auction Auction { get; set; } = null!;

        public long SellerId { get; set; }
        public Seller Seller { get; set; } = null!;

        public long BuyerId { get; set; }
        public Buyer Buyer { get; set; } = null!;

        public long ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public decimal FinalPrice { get; set; }
    }

}
