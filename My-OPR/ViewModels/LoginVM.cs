using System.ComponentModel.DataAnnotations;

namespace My_OPR.ViewModels
{
    public class LoginVM
    {
        [Required]
        public string? NPP { get; set; }
        [Required]
        public string? Password { get; set; }    
    }
}
