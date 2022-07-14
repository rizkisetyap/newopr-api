using My_OPR.Models.DocumentISO;
namespace My_OPR.ViewModels
{
    public class UploadIsoVM
    {
        public FileInfo? FileIso { get; set; }
        public FileRegisteredIso? FileRegisteredIso { get; set; }
        public string? npp { get; set; }
    }

    public class UploadDokumenUtamaVM
    {
        public FileInfo? FileIso { get; set; }
        public ISOCore? ISOCore { get; set; }
    }
}