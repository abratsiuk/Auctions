using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Buyer
    {
        public long Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [MaxLength(100)]
        public string Email { get; set; } = null!;

        public ICollection<TradeResult>? TradeResults { get; set; }
        public ICollection<TradeProcess>? TradeProcesses { get; set; }
    }

}
