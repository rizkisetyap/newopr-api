using System.Text.Json.Serialization;

namespace My_OPR.Models.DocumentISO
{
    public class ISOCore
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? FilePath { get; set; }
        public int Revision { get; set; } = 0;
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDelete { get; set; } = false;
        [JsonIgnore]
        public virtual ICollection<ISOSupport>? Support { get; set; }
    }
}
