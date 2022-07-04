using My_OPR.Models.Core;

namespace My_OPR.Models.Master
{
    public class ExtUser : BaseModel
    {
        public int Id { get; set; }
        public string? NPP { get; set; }
        public string? Nama { get; set; }
        public string? Unit { get; set; }
        public string? Telp { get; set; }
        public string? Email { get; set; }
    }
}
