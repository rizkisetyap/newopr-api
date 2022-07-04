using My_OPR.Models.Core;
using My_OPR.Models.Transaction;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace My_OPR.Models.Master
{
    public class Employee : BaseModel
    {
        [Key]
        public string? NPP { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public Gender? Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        [JsonIgnore]
        public virtual Account? Account { get; set; }
        [JsonIgnore]
        public virtual Service? Service { get; set; }
        public int? ServiceId { get; set; }
        [JsonIgnore]
        public virtual Position? Position { get; set; }
        public int PositionId { get; set; }
        [JsonIgnore]

        public virtual ICollection<Presence>? Presences { get; set; }

    }

    public enum Gender
    {
        Male,
        Female
    }
}
