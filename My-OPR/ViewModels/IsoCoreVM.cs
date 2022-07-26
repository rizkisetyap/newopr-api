using My_OPR.Models.DocumentISO;


namespace My_OPR.ViewModels
{

    public class IsoCoreVM
    {
        public ISOCore ISOCore { get; set; }
        public FileInfo file { get; set; }
        public int ServiceId { get; set; }
    }
    public class UpdateIsoCoreVM
    {
        public string? name { get; set; }
        public FileInfo File { get; set; }
    }
}