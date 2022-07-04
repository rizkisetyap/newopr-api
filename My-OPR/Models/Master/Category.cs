using My_OPR.Models.Core;
using My_OPR.Models.Transaction;
using System.Text.Json.Serialization;

namespace My_OPR.Models.Master
{
    public class Category : BaseModel
    {
        public int Id { get; set; }
        public string? Nama { get; set; }
        public string? Icon { get; set; }
        public bool IsMainCategory { get; set; }
        [JsonIgnore]
        public virtual ICollection<Content>? Contents { get; set; }
    }
}
