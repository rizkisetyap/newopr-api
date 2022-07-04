using My_OPR.Models.Core;
using System.Text.Json.Serialization;

namespace My_OPR.Models.Master
{
    public class Position : BaseModel
    {
        public int Id { get; set; }
        public string? PositionName { get; set; }
        [JsonIgnore]
        public virtual ICollection<Employee>? Employees { get; set; }
        public int Grade { get; set; } = 0;
    }
}
