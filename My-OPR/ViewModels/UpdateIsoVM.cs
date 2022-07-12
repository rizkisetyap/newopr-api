using System.ComponentModel.DataAnnotations;
namespace My_OPR.ViewModels
{
    public class UpdateIsoVM
    {
        public string? fileName { get; set; }
        public FileInfo? document { get; set; }
    }
}