using My_OPR.Models.Master;

namespace My_OPR.Models.Core
{
    public class BaseModelTransaction
    {
        public DateTime CreateDate { get; set; }
        public virtual Employee Creater { get; set; }
        public string CreaterId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public virtual Employee Updater { get; set; }
        public string UpdaterId { get; set; }
        public DateTime? PublishDate { get; set; }
        public virtual Employee Publisher { get; set; }
        public string PublisherId { get; set; }
        public bool IsPublish { get; set; }
        public DateTime? DeleteDate { get; set; }
        public virtual Employee Deleter { get; set; }
        public string DeleterId { get; set; }
        public bool IsDelete { get; set; }
    }
}
