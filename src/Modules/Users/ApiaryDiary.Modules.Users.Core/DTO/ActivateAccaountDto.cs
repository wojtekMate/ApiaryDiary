using System.ComponentModel.DataAnnotations;

namespace ApiaryDiary.Modules.Users.Core.DTO
{
    public class ActivateAccaountDto
    {
        [Required]
        public string Token { get; set; }

    }
}