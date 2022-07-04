using System.Text.Json.Serialization;
using My_OPR.Models.Master;

namespace My_OPR.Models.ZoomScheduler
{
    public class Scheduler
    {
        public int Id { get; set; }
        public string? Activity { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.Now;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int ZoomId { get; set; }
        public bool IsDelete { get; set; }
        [JsonIgnore]
        public virtual ZoomModel? ZoomModel { get; set; }
        public int ZoomStatusId { get; set; }
        [JsonIgnore]
        public virtual ZoomStatus? ZoomStatus { get; set; }


        [JsonIgnore]
        public virtual Employee? Employee { get; set; }
        public string? EmployeeNPP { get; set; }

        public string? link { get; set; }
    }
}
