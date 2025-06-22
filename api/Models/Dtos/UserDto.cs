using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class UserDto
    {
        public long Id { get; set; }

        [MaxLength(100)]
        public string UserName { get; set; } = null!;

    }
}
