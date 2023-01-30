using System.ComponentModel.DataAnnotations;

namespace MyApplicationAPI.Model
{
    public class Login
    {
        [Required(ErrorMessage = "User name is  Required! ")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "User name is  Required! ")]
        public string? Password { get; set; }
    }
}
