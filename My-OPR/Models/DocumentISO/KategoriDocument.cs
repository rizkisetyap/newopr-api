using System.Text.Json.Serialization;
using My_OPR.Models.Core;

namespace My_OPR.Models.DocumentISO
{
    public class KategoriDocument : BaseModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<RegisteredForm>? RegisteredForms { get; set; }
    }
}