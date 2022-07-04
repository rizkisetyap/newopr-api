using System.Text.Json.Serialization;

namespace My_OPR.Models.Master
{
    public class Role
    {
        public string? Id { get; set; }
        public string? RoleName { get; set; }
        [JsonIgnore]
        public virtual ICollection<AccountRole>? AccountRoles { get; set; }
    }
}
