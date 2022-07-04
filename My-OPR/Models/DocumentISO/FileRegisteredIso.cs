using System.Text.Json.Serialization;
using My_OPR.Models.Core;

namespace My_OPR.Models.DocumentISO
{
    public class FileRegisteredIso : BaseModel
    {
        public int Id { get; set; }
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public int DetailRegisterId { get; set; }
        [JsonIgnore]
        public virtual DetailRegister? DetailRegister { get; set; }

    }
}