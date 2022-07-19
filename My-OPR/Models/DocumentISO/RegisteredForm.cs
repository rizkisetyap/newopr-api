using My_OPR.Models.Master;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace My_OPR.Models.DocumentISO
{
    public class RegisteredForm
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsDelete { get; set; } = false;
        public int? ServiceId { get; set; }
        [JsonIgnore]
        public virtual Service? Service { get; set; }
        public int? GroupId { get; set; }
        [JsonIgnore]
        public virtual Group? Group { get; set; }
        public int? SubLayananId { get; set; }
        [JsonIgnore]
        public virtual SubLayanan? Unit { get; set; }
        public int Month { get; set; } = DateTime.Now.Month;
        public int Year { get; set; } = DateTime.Now.Year;

        // public int? KategoriDocumentId { get; set; }
        // public virtual KategoriDocument? KategoriDocument { get; set; }
        public int? JenisDokumenId { get; set; }
        [JsonIgnore]
        public JenisDocument? JenisDokumen { get; set; }
        public int NoUrut { get; set; }
        public string? FormNumber { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? UpdateDate { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? CreateDate { get; set; } = DateTime.Now;
        public DateTime? DeleteDate { get; set; }
        public virtual ICollection<DetailRegister>? DetailRegisters { get; set; }
    }
}
