using System.ComponentModel.DataAnnotations;

namespace ApiaryDiary.Application.Users.DTO
{
    public class SignInDto
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}