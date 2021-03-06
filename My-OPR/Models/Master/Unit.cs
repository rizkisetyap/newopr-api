using My_OPR.Models.Core;
using System.Text.Json.Serialization;
namespace My_OPR.Models.Master
{
    public class SubLayanan : BaseModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ShortName { get; set; }
        public int? ServiceId { get; set; }
        [JsonIgnore]
        public Service? Services { get; set; }
    }
}