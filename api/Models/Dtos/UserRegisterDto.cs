using System.ComponentModel.DataAnnotations;

namespace api.Models.Dtos
{
    public class UserRegisterDto
    {
        [MaxLength(100)]
        public string UserName { get; set; } = null!;
        [MaxLength(100)]
        public string Password { get; set; } = null!;
    }
}
