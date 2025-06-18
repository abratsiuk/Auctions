namespace api.Models.Dtos
{
    public class AuctionDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime AuctionDate { get; set; }
    }
}
