using System.ComponentModel.DataAnnotations;

namespace My_OPR.ViewModels
{
    public class LoginDataVM
    {
        [Required]
        public string? NPP { get; set; }
        public string? AccountId { get; set; }  
        public List<string> Roles { get; set; } 
    }
}
