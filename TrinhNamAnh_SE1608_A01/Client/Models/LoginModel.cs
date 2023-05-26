using System.ComponentModel.DataAnnotations;

namespace Client.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; } = null!;
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        public bool RememberLogin { get; set; } = false;
        public string ReturnUrl { get; set; } = "~/Product/Index";
    }
}
