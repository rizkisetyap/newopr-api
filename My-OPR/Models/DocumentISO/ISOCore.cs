using System.Text.Json.Serialization;
using My_OPR.Models.Master;
namespace My_OPR.Models.DocumentISO
{
    public class ISOCore
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? FilePath { get; set; }
        public int? UnitId { get; set; }
        public SubLayanan? Unit { get; set; }
        public int? JenisDokumenId { get; set; }
        [JsonIgnore]
        public JenisDocument? JenisDocument { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDelete { get; set; } = false;
    }
}
