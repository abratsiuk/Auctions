namespace api.Models
{
    public class Seller
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;

        public long UserId { get; set; }
        public User User { get; set; } = null!;

        public ICollection<InitialOffer>? InitialOffers { get; set; }
        public ICollection<TradeResult>? TradeResults { get; set; }
    }

}
