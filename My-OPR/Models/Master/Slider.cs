using My_OPR.Models.Core;

namespace My_OPR.Models.Master
{
    public class Slider : BaseModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Path { get; set; }
    }
}
