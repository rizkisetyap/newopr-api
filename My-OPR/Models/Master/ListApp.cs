using My_OPR.Models.Core;

namespace My_OPR.Models.Master
{
    public class ListApp : BaseModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Link { get; set; }
    }
}