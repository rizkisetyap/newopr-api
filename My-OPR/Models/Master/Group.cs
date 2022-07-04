using My_OPR.Models.Core;
using System.Text.Json.Serialization;

namespace My_OPR.Models.Master
{
    public class Group : BaseModel
    {
        public int Id { get; set; }
        public string? GroupName { get; set; }
        [JsonIgnore]
        public virtual ICollection<Employee>? Employees { get; set; }
        [JsonIgnore]


        public virtual ICollection<Service>? Services { get; set; }

    }
}
