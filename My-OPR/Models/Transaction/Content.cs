using My_OPR.Models.Core;
using My_OPR.Models.Master;

namespace My_OPR.Models.Transaction
{
    public class Content : BaseModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? BodyContent { get; set; }
        public string? PathImage { get; set; }
        public string? PathContent { get; set; }
        public virtual Category? Category { get; set; }
        public int CategoryId { get; set; }
    }
}
