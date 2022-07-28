using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using My_OPR.Data;
using My_OPR.Models.Master;
using My_OPR.Repositories.Data;
//using My_OPR.ViewModels;
using OfficeOpenXml;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace My_OPR.Controllers.Master
{
    // [EnableCors]
    [Route("Api/[controller]")]
    [ApiController]
    public class AccountsController : BaseController<Account, AccountRepository, string>
    {
        private readonly AccountRepository _accountRepository;
        private readonly EmployeeRepository _employeeRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ApplicationDBContext _context;
        public IConfiguration _configuration;

        public AccountsController(AccountRepository accountRepository
            , EmployeeRepository employeeRepository
            , IConfiguration configuration, ApplicationDBContext context, IWebHostEnvironment webHostEnvironment) : base(accountRepository)
        {
            _accountRepository = accountRepository;
            _employeeRepository = employeeRepository;
            _context = context;

            _configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
            // _accountRepository.DataSeed();
        }
        #region  Login
        [HttpPost]
        [Route("/api/login")]
        public ActionResult Login(ViewModels.LoginVM login)
        {
            var exist = _accountRepository.Get(login.NPP);
            if (exist == null)
            {
                return Ok(new ViewModels.JWTokenVM
                {
                    status = HttpStatusCode.NotFound,
                    idToken = null,
                    message = "Account Not Found!"
                });
            }
            int logged = _accountRepository.Login(login.NPP, login.Password);

            if (logged == 1)
            {
                string npp = login.NPP;
                string roles = _accountRepository.TokenPayload(login.NPP).Roles.FirstOrDefault()!;
                string fullName = _employeeRepository.Get(login.NPP).FirstName!;
                var employee = _employeeRepository.Get(npp);

                var claims = new List<Claim>
                {
                    new Claim("npp", npp),
                    new Claim("name", fullName),
                    //new Claim("role", roles)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddYears(30),
                    signingCredentials: signIn
                    );
                var idToken = new JwtSecurityTokenHandler().WriteToken(token);
                claims.Add(new Claim("Token Security", idToken.ToString()));

                ViewModels.UserInfo userinfo = new ViewModels.UserInfo();
                userinfo.FirstName = employee.FirstName;
                userinfo.LastName = employee.LastName;
                userinfo.NPP = employee.NPP;
                userinfo.AccountRole = _context.AccountRoles.Include(x => x.Role).Where(x => x.NPP == employee.NPP).Select(x => x.Role!.RoleName).ToList()!;

                userinfo.Employee = employee;

                return Ok(new ViewModels.JWTokenVM
                {
                    status = HttpStatusCode.OK,
                    idToken = idToken,
                    message = "Successfully Login!",
                    UserInfo = userinfo
                });
            }
            else if (logged == 2)
            {
                var result = new ViewModels.JWTokenVM
                {
                    status = HttpStatusCode.NotFound,
                    idToken = null,
                    message = "Not Account Found!"
                };
                return NotFound(result);
            }
            else if (logged == 3)
            {
                var result = new ViewModels.JWTokenVM
                {
                    status = HttpStatusCode.BadRequest,
                    idToken = null,
                    message = "Password Incorect!"
                };
                return BadRequest(result);
            }
            return NotFound(new ViewModels.JWTokenVM
            {
                idToken = null,
                message = "No Data found!",
                status = HttpStatusCode.NotFound
            });
        }
        #endregion
        [HttpGet]
        [Route("/api/account/UserInfo")]
        public ActionResult UserInfo(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                return BadRequest();
            }
            else
            {
                var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);
                string npp = jwt.Claims.First(c => c.Type == "npp").Value;

                var user = _employeeRepository.Get(npp);

                return Ok(user);
            }
        }
        [HttpPost]
        [Route("register")]
        public IActionResult Register(ViewModels.RegisterAccountVM model)
        {
            _accountRepository.RegisterAccount(model);

            return Ok();
        }
        [HttpGet]
        [Route("/api/UserManagement")]
        public ActionResult UserManagement()
        {
            return Ok(_accountRepository.GetAllUsers());
        }
        [HttpPost]
        [Route("UploadUser")]
        public IActionResult UploadUser(IFormFile files)
        {
            #region Upload 
            if (files.FileName.EndsWith("xlsx") || files.FileName.EndsWith("xls"))
            {
                try
                {
                    string webRootPath = _webHostEnvironment.WebRootPath;
                    string paths = Path.Combine(webRootPath, "file");
                    string generateNameFile = files.FileName;
                    FileStream path = new FileStream(Path.Combine(paths, generateNameFile), FileMode.Create);
                    files.CopyTo(path);
                    path.Close();

                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    var namePath = Path.Combine(paths, generateNameFile);
                    FileInfo existingFile = new FileInfo(namePath);
                    using (ExcelPackage package = new ExcelPackage(existingFile))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault(f => f.View.TabSelected);
                        if (worksheet != null)
                        {
                            var rowCount = worksheet.Dimension.End.Row;

                            string no = worksheet.Cells[1, 1].Text;
                            string produkKartu = worksheet.Cells[1, 2].Text;
                            //string wilayah = worksheet.Cells[1, 4].Text;
                            string NamaCabang = worksheet.Cells[1, 3].Text;
                            string stok = worksheet.Cells[1, 4].Text;

                            no = no.Replace(" ", "").ToLower();
                            produkKartu = produkKartu.Replace(" ", "").ToLower();
                            NamaCabang = NamaCabang.Replace(" ", "").ToLower();
                            stok = stok.Replace(" ", "").ToLower();

                            //cek coloum sesuai template 
                            //insert Wilayah 

                            for (int row = 2; row <= rowCount; row++)
                            {
                                //get dari excel
                                string jenisKartu = worksheet.Cells[row, 2].Text;
                                string nama = worksheet.Cells[row, 3].Text.Replace(" ", "").ToUpper();

                                string kcu = worksheet.Cells[row, 4].Text;

                            }


                        }
                    }

                }
                catch (Exception e)
                {
                    return BadRequest();
                }


            }

            #endregion

            return Ok();
        }

    }



}
