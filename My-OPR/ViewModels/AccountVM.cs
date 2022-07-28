using My_OPR.Models.Master;
using System.ComponentModel.DataAnnotations;

namespace My_OPR.ViewModels
{
    public class AccountVM
    {
        [Required(ErrorMessage = "Npp harus diisi")]
        public string? NPP { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public Gender? gender { get; set; }
        public int? ServiceId { get; set; }
        public int PositionId { get; set; }
        public int? GroupId { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
