namespace My_OPR.ViewModels
{
    public class UploadVM
    {
        public int entityId { get; set; }
        public string? base64 { get; set; }
        public string? name { get; set; }
        public string? type { get; set; }
        public string? extension { get; set; }
    }
}