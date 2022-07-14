using System.Text.Json.Serialization;

namespace My_OPR.Models.DocumentISO
{
    public class HistoryISO
    {
        public int Id { get; set; }
        public bool IsDelete { get; set; } = false;
        public int? ISOCoreId { get; set; }
        [JsonIgnore]
        public ISOCore? ISOCore { get; set; }
        public int Revision { get; set; } = 0;
        public DateTime? CreateDate { get; set; } = DateTime.Now;
        public DateTime? UpdateDate { get; set; }

    }
}
