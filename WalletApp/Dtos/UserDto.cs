using System.ComponentModel.DataAnnotations;

namespace WalletAppApi.Dtos
{
    public class UserDto
    {
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public DateTime Created { get; set; }
    }
}
