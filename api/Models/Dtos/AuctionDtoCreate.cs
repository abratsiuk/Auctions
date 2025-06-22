using System.ComponentModel.DataAnnotations;

namespace api.Models.Dtos
{
    public class AuctionDtoCreate

    {
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        public DateTime AuctionDate { get; set; }
    }
}
