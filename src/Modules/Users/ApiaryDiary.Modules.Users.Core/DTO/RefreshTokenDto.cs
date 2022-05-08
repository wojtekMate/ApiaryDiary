using System.ComponentModel.DataAnnotations;

namespace ApiaryDiary.Modules.Users.Core.DTO
{
    public class RefreshTokenDto
    {
        [Required]
        public string RefreshToken { get; set; }
    }
}
