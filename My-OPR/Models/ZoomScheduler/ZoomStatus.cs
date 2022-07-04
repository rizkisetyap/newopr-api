using System.Text.Json.Serialization;

namespace My_OPR.Models.ZoomScheduler
{
    public class ZoomStatus
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsDelete { get; set; }
        [JsonIgnore]
        public ICollection<Scheduler>? Schedulers { get; set; }
    }
}
