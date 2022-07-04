using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using My_OPR.Models.Master;
using My_OPR.Repositories.Data;
using My_OPR.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using My_OPR.Data;
using Microsoft.EntityFrameworkCore;

namespace My_OPR.Controllers.Master
{
    // [EnableCors]
    [Route("Api/[controller]")]
    [ApiController]
    public class AccountsController : BaseController<Account, AccountRepository, string>
    {
        private readonly AccountRepository _accountRepository;
        private readonly EmployeeRepository _employeeRepository;
        private readonly ApplicationDBContext _context;
        public IConfiguration _configuration;

        public AccountsController(AccountRepository accountRepository
            , EmployeeRepository employeeRepository
            , IConfiguration configuration, ApplicationDBContext context) : base(accountRepository)
        {
            _accountRepository = accountRepository;
            _employeeRepository = employeeRepository;
            _context = context;

            _configuration = configuration;
            // _accountRepository.DataSeed();
        }
        #region  Login
        [HttpPost]
        [Route("/api/login")]
        public ActionResult Login(LoginVM login)
        {
            var exist = _accountRepository.Get(login.NPP);
            if (exist == null)
            {
                return Ok(new JWTokenVM
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

                UserInfo userinfo = new UserInfo();
                userinfo.FirstName = employee.FirstName;
                userinfo.LastName = employee.LastName;
                userinfo.NPP = employee.NPP;
                userinfo.AccountRole = _context.AccountRoles.Include(x => x.Role).Where(x => x.NPP == employee.NPP).Select(x => x.Role!.RoleName).ToList()!;
                var s = _context.Services.Include(x => x.Group).Where(s => s.Id == employee.ServiceId).FirstOrDefault();
                userinfo.Service = s.Name;
                userinfo.Kelompok = s.Group.GroupName;
                userinfo.Jabatan = employee.Position.PositionName;

                return Ok(new JWTokenVM
                {
                    status = HttpStatusCode.OK,
                    idToken = idToken,
                    message = "Successfully Login!",
                    UserInfo = userinfo
                });
            }
            else if (logged == 2)
            {
                var result = new JWTokenVM
                {
                    status = HttpStatusCode.NotFound,
                    idToken = null,
                    message = "Not Account Found!"
                };
                return NotFound(result);
            }
            else if (logged == 3)
            {
                var result = new JWTokenVM
                {
                    status = HttpStatusCode.BadRequest,
                    idToken = null,
                    message = "Password Incorect!"
                };
                return BadRequest(result);
            }
            return NotFound(new JWTokenVM
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
        public IActionResult Register(RegisterAccountVM model)
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

    }



}
