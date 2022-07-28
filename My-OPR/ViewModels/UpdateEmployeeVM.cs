using My_OPR.Models.Master;

namespace My_OPR.ViewModels
{
    public class UpdateEmployeeVM
    {
        public Employee? Employee { get; set; }
        public ICollection<Role> roles { get; set; }

    }
}
