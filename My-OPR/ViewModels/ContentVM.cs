using My_OPR.Models.Transaction;
namespace My_OPR.ViewModels
{
    public class FileInfo
    {
        public string? name { get; set; }
        public string? type { get; set; }
        public string? extension { get; set; }
        public string? base64str { get; set; }
    }
    public class FileData
    {
        public FileInfo? image { get; set; }
        public FileInfo? file { get; set; }
    }
    public class ContentVM
    {
        public Content? content { get; set; }
        public FileData fileData { get; set; }

    }
}