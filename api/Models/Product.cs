using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Product
    {
        public long Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; } = null!;
        [MaxLength(100)]
        public string Category { get; set; } = null!;
        [MaxLength(100)]
        public string? Subcategory { get; set; }

        public ICollection<InitialOffer>? InitialOffers { get; set; }
        public ICollection<TradeResult>? TradeResults { get; set; }
        public ICollection<TradeProcess>? TradeProcesses { get; set; }
    }

}
