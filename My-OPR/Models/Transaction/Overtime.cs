using My_OPR.Models.Core;
using My_OPR.Models.Master;
using System.ComponentModel.DataAnnotations;
namespace My_OPR.Models.Transaction
{
    public class RequestOvertimeStatus
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }

    }
    public class OvertimeDetail
    {
        public Guid Id { get; set; }
        public int RequestOvertimeStatusId { get; set; }
        public RequestOvertimeStatus? RequestOvertimeStatus { get; set; }
        public string? RequesterId { get; set; }
        public Employee? Requester { get; set; }

        public DateTime? TanggalApprove { get; set; }
        public string? Catatan { get; set; }
        public Guid OvertimeId { get; set; }
        public Overtime? Overtime { get; set; }

    }
    public class Overtime : BaseModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string? UserId { get; set; }
        public Employee? User { get; set; }
        public string? Nama { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Tanggal { get; set; }
        public DateTime? JamMulai { get; set; }
        public DateTime? JamSelesai { get; set; }
        public string? Alasan { get; set; }
        public string? ApprovalId { get; set; }
        public Employee? Approval { get; set; }


    }
}
