using System.ComponentModel.DataAnnotations;

namespace OlSoftwareFront.Model
{
    public class Autentication
    {

        [Required]
        public string UserName { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
