using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace My_OPR.Models.Master
{
    public class Account
    {
        [Key]
        public string? NPP { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        [JsonIgnore]
        public virtual Employee? Employee { get; set; }
        [JsonIgnore]
        public virtual ICollection<AccountRole>? Roles { get; set; }


    }
}
