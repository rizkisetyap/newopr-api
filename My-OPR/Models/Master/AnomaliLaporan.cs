using System.Text.Json.Serialization;
namespace My_OPR.Models.Master;

public class AnomaliLaporan
{
    public int Id { get; set; }
    public String? Anomali { get; set; }
    public String? Keterangan { get; set; }
    public int ServiceId { get; set; }

    [JsonIgnore]
    public Service? Layanan { get; set; }

}