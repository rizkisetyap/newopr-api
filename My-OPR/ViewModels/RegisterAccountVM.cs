using System.ComponentModel.DataAnnotations;
using My_OPR.Models.Master;

namespace My_OPR.ViewModels
{
    public class RegisterAccountVM : AccountVM
    {


        [Required(ErrorMessage = "Nama depan harus diisi")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Nama belakang harus diisi")]
        public string? LastName { get; set; }
        public ICollection<Role>? roles { get; set; }


    }
}