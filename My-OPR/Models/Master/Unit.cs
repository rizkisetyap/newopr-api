using System.Text.Json.Serialization;
using My_OPR.Models.Core;
namespace My_OPR.Models.Master
{
    public class SubLayanan : BaseModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int ServiceId { get; set; }
        [JsonIgnore]
        public ICollection<Service>? Services { get; set; }
    }
}