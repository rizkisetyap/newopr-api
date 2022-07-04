using System.Text.Json.Serialization;

namespace My_OPR.Models.DocumentISO
{
    public class HistoryISO
    {
        public int Id { get; set; }
        public bool IsDelete { get; set; } = false;
        public int IsoSupportId { get; set; }
        public int Revision { get; set; } = 0;
        [JsonIgnore]
        public virtual ISOSupport? ISOSupport { get; set; }
        public string? FilePath { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.Now;

    }
}
