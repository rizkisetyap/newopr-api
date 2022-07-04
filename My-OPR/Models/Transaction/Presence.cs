using My_OPR.Models.Master;

namespace My_OPR.Models.Transaction
{
    public class Presence
    {
        public int Id { get; set; }
        public virtual Event? Event { get; set; }
        public int EventId { get; set; }
        public virtual Employee? Employee { get; set; }
        public string? NPP { get; set; }
        public virtual ExtUser? ExtUser { get; set; }
        public int? ExtUserId { get; set; }
        public bool IsInternal { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
