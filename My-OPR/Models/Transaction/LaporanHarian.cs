using My_OPR.Models.Core;
using My_OPR.Models.Master;
using System.Text.Json.Serialization;
namespace My_OPR.Models.Transaction;

public class LaporanHarian : BaseModel
{
    public int Id { get; set; }
    public int ApprovalId { get; set; }
    public DateTime TanggalTransaksi { get; set; }
    [JsonIgnore]
    public virtual Group? Group { get; set; }
    public int GroupId { get; set; }
    public Boolean IsAnomaly { get; set; } = false;

    public AnomaliLaporan? Anomali { get; set; }
}
