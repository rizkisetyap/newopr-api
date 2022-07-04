using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public PresenceController(EventRepository repository, EmployeeRepository empoyee)
        {
            _repository = repository;
            _empoyee = empoyee;
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
            int result = 0;
            if (string.IsNullOrEmpty(token))
            {
                throw new Exception("Error: Please Login!");
            }
            else
            {
                var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);
                string npp = jwt.Claims.First(c => c.Type == "npp").Value;
                result = _repository.EventPresence(id, npp);
            }
            return Ok(result);
        }
    }
}
