namespace My_OPR.Models.Core
{
    public class BaseModel
    {
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsDelete { get; set; }
    }
}
