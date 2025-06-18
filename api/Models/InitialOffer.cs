namespace api.Models
{
    public class InitialOffer
    {
        public long Id { get; set; }

        public long AuctionId { get; set; }
        public Auction Auction { get; set; } = null!;

        public long ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public long SellerId { get; set; }
        public Seller Seller { get; set; } = null!;

        public decimal StartPrice { get; set; }
    }

}
