using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiaryDiary.Application.Users.DTO
{
    public class ActivateAccaountDto
    {
        [Required]
        public string Token { get; set; }

    }
}