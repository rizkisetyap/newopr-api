using My_OPR.Models.Core;
using My_OPR.Models.Transaction;
using System.Text.Json.Serialization;

namespace My_OPR.Models.Master
{
    public class Event : BaseModel
    {
        public int Id { get; set; }
        public string? EventName { get; set; }
        public string? EventTheme { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Organizer { get; set; }
        public string? Location { get; set; }
        public bool IsActive { get; set; }
        [JsonIgnore]
        public virtual ICollection<Presence>? Presence { get; set; }
    }
}
