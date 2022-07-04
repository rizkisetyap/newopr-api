using My_OPR.Models.Core;

namespace My_OPR.Models.DocumentISO
{
    public class DetailRegister : BaseModel
    {
        public int Id { get; set; }
        public int RegisteredFormId { get; set; }
        public int Revisi { get; set; }
        public bool isActive { get; set; }

        public virtual RegisteredForm? RegisteredForm { get; set; }
        public virtual FileRegisteredIso? FileRegisteredIso { get; set; }

    }
}