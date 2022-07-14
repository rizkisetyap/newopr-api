using My_OPR.Models.Core;
using System.Text.Json.Serialization;
namespace My_OPR.Models.Master
{
    public class ListApp : BaseModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Link { get; set; }
        public int? GroupId { get; set; }
        [JsonIgnore]
        public Group? Group { get; set; }
    }
}