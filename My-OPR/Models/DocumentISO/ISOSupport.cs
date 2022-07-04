using System.Text.Json.Serialization;

namespace My_OPR.Models.DocumentISO
{
    public class ISOSupport
    {
        public int Id { get; set; }
        public bool IsDelete { get; set; } = false;
        public int ISOCoreId { get; set; }
        [JsonIgnore]
        public virtual ISOCore? ISOCore { get; set; }
        public int RegisteredFormId { get; set; }
        [JsonIgnore]
        public virtual RegisteredForm? RegisteredForm { get; set; }
        public int? Revision { get; set; } = 0;
        public string? FilePath { get; set; }
        [JsonIgnore]
        public virtual ICollection<HistoryISO>? HistoryISOs { get; set; }
    }
}

