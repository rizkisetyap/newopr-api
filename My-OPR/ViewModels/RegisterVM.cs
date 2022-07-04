using My_OPR.Models.Master;

namespace My_OPR.ViewModels
{
    public class RegisterVM
    {
        public Employee Employee { get; set; }
        public ICollection<Role> Roles { get; set; }
    }
}