using System.ComponentModel.DataAnnotations;
namespace My_OPR.Models.Master
{
    public class AccountRole
    {
        [Key]
        public int Id { get; set; }
        public string? NPP { get; set; }
        public virtual Account? Account { get; set; }
        public virtual Role? Role { get; set; }
        public string? RoleId { get; set; }

    }
}
