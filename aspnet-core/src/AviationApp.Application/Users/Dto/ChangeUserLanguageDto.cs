using System.ComponentModel.DataAnnotations;

namespace AviationApp.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}