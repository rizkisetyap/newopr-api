using My_OPR.Models.Master;
using System.Text.Json.Serialization;
namespace My_OPR.Models.DocumentISO
{
    public class ISOCore
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? FilePath { get; set; }
        public int? GroupId { get; set; }
        public Group? Group { get; set; }
        public int? JenisDocumentId { get; set; }
        [JsonIgnore]
        public JenisDocument? JenisDocument { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDelete { get; set; } = false;
    }
}
