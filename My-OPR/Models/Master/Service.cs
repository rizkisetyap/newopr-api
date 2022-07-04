using My_OPR.Models.DocumentISO;
using System.Text.Json.Serialization;

namespace My_OPR.Models.Master
{
    public class Service
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public String? ShortName { get; set; }
        public bool IsDelete { get; set; } = false;
        public int GroupId { get; set; }
        [JsonIgnore]

        public virtual Group? Group { get; set; }
        public KategoriService KategoriService { get; set; }

        [JsonIgnore]
        public virtual ICollection<RegisteredForm>? RegisteredForms { get; set; }
        [JsonIgnore]
        public virtual ICollection<Employee>? Employees { get; set; }
    }
    public enum KategoriService
    {
        Transaksi,
        Aktivitas,
        Laporan
    }
}
