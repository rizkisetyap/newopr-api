using My_OPR.Models.DocumentISO;
using My_OPR.Models.Core;
using System.Text.Json.Serialization;
namespace My_OPR.Models.DocumentISO
{
    public class JenisDocument : BaseModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? KategoriDokumenId { get; set; }
        [JsonIgnore]
        public KategoriDocument? KategoriDokumen { get; set; }
        [JsonIgnore]
        public ICollection<RegisteredForm>? RegisteredForms { get; set; }
    }
}