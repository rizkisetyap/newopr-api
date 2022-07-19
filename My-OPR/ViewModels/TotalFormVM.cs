using My_OPR.Models.DocumentISO;
namespace My_OPR.ViewModels
{
    public class RegVM
    {
        public int? Id {get; set;}
        public int? idForm {get; set;}
        public string? namaForm {get; set;}

        public string? formNumber{get;set;}
    }
    public class TotalFormVm
    {
        public int? idGroup {get; set;}
        public string? namaGroup {get; set; }
        public ICollection<RegVM>? listForms {get; set;}
    }
}