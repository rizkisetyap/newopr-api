using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My_OPR.Data;
using My_OPR.Models.Master;
using My_OPR.Repositories.Data;
using My_OPR.ViewModels;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;
using System.IdentityModel.Tokens.Jwt;

namespace My_OPR.Controllers.Transaction
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresenceController : ControllerBase
    {
        private readonly EventRepository _repository;
        private readonly EmployeeRepository _empoyee;
        private readonly ApplicationDBContext _context;
        public PresenceController(EventRepository repository, EmployeeRepository empoyee, ApplicationDBContext context)
        {
            _repository = repository;
            _empoyee = empoyee;
            _context = context;
        }

        public static byte[] BitmapToByteArray(Bitmap bitmap)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }

        [HttpGet]
        [Route("/api/[controller]/{id}")]
        public ActionResult Presences(int id)
        {
            EventQRVM eventQRVM = new EventQRVM();
            Event events = _repository.Get(id);
            string qrcodes = "";
            string DateLocation = "";

            if (events != null)
            {
                #region Lokasi Tanggal
                var Sday = events.StartDate.ToString("dd", new System.Globalization.CultureInfo("id-ID"));
                var Smonth = events.StartDate.ToString("MMMM", new System.Globalization.CultureInfo("id-ID"));
                var Syear = events.StartDate.ToString("yyyy", new System.Globalization.CultureInfo("id-ID"));
                var Eday = events.EndDate.ToString("dd", new System.Globalization.CultureInfo("id-ID"));
                var Emonth = events.EndDate.ToString("MMMM", new System.Globalization.CultureInfo("id-ID"));
                var Eyear = events.EndDate.ToString("yyyy", new System.Globalization.CultureInfo("id-ID"));
                // Url = "myopr/id&token=";


                if (Syear == Eyear)
                {
                    if (Smonth == Emonth)
                    {
                        if (Sday == Eday)
                        {
                            DateLocation = Eday + " " + Emonth + " " + Eyear;
                        }
                        else
                        {
                            DateLocation = Sday + " - " + Eday + " " + Emonth + " " + Eyear;
                        }

                    }
                    else
                    {
                        DateLocation = Sday + " " + Smonth + " - " + Eday + " " + Emonth + " " + Eyear;
                    }
                }
                else
                {
                    DateLocation = Sday + " " + Smonth + " " + Syear + " - " + Eday + " " + Emonth + " " + Eyear;
                }
                #endregion

                DateLocation = events.Location + ", " + DateLocation;

                #region Create QR
                qrcodes = "{\"id\":" + events.Id + ",\"nama\":\"" + events.EventName + "\"}";
                using (MemoryStream ms = new MemoryStream())
                {
                    QRCodeGenerator qrGenerator = new QRCodeGenerator();
                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrcodes, QRCodeGenerator.ECCLevel.Q);
                    QRCode qrCode = new QRCode(qrCodeData);
                    Bitmap qrBitmap = qrCode.GetGraphic(20);
                    byte[] BitmapArray = BitmapToByteArray(qrBitmap);
                    eventQRVM.QrSrc = String.Format(
                        "data:image/png;base64,{0}",
                        Convert.ToBase64String(BitmapArray));
                }
                #endregion

                eventQRVM.Name = events.EventName;
                eventQRVM.Id = events.Id;
                eventQRVM.Organizer = events.Organizer;
                eventQRVM.DateLocation = DateLocation;
            }
            return Ok(eventQRVM);
        }

        [HttpPost]
        [Route("/api/[controller]")]
        public ActionResult Presences(int id, string token)
        {
            try
            {
                int result = 0;
                if (string.IsNullOrEmpty(token))
                {
                    return StatusCode(StatusCodes.Status401Unauthorized, new { message = "Please Login" });
                }
                else
                {
                    var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);
                    string npp = jwt.Claims.First(c => c.Type == "npp").Value;
                    if (string.IsNullOrEmpty(npp))
                    {
                        return StatusCode(StatusCodes.Status400BadRequest, "Invalid Credentials");
                    }

                    result = _repository.EventPresence(id, npp);
                    return Ok(result);
                }
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }
        [HttpGet]
        [Route("event")]
        public IActionResult GetLaporan(int Id)
        {

            var daftarAbsen = _context.Presences
                .Include(x => x.Employee)
                .Include(x => x.Employee.Service)
                .Include(x => x.Employee.Service.Group)
                .Include(x => x.Event)
                .Where(x => x.EventId == Id)
                .OrderBy(x => x.CreateDate)
                .Select(x => new
                {
                    Id = x.Id,
                    Nama = x.Employee.FirstName + " " + x.Employee.LastName,
                    Npp = x.Employee.NPP,
                    TanggalAbsen = x.CreateDate,
                    Kelompok = x.Employee.Service.Group.GroupName


                });

            return Ok(daftarAbsen);
        }
        [HttpGet]
        [Route("employee")]
        public IActionResult GetEmployeePressence(string npp)
        {
            var list = _context.Presences
                .Include(x => x.Event)
                .Where(x => x.NPP == npp)
                .Select(x => new
                {
                    IdEvent = x.EventId,
                    NamaEvent = x.Event.EventName,
                    TanggalMulai = x.Event.StartDate,
                    TanggalSelesai = x.Event.EndDate,
                    WaktuAbsen = x.CreateDate
                }).ToList();

            return Ok(list);
        }
    }
}
