using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class User
    {
        public long Id { get; set; }

        [MaxLength(100)]
        public string UserName { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;

        public Buyer? Buyer { get; set; }
        public Seller? Seller { get; set; }
    }
}
