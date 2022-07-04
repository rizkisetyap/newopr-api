using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using My_OPR.Data;
using My_OPR.Models.Master;
using My_OPR.ViewModels;
using Dapper;

namespace My_OPR.Repositories.Data
{
    public class AccountRepository : GenericRepository<ApplicationDBContext, Account, string>
    {
        private readonly ApplicationDBContext _context;
        private IConfiguration _configuration;
        SqlConnection _connection;

        public AccountRepository(ApplicationDBContext context,
            IConfiguration configuration) : base(context)
        {
            _context = context;
            _configuration = configuration;
            _connection = new SqlConnection(_configuration.GetConnectionString("MyOPR"));
        }
        #region Get All User
        public List<AccountVM> GetAllUsers()
        {
            var data = (from user in _context.Accounts.Include(x => x.Employee).ToList()
                        select new AccountVM
                        {
                            FullName = user.Employee.FirstName + " " + user.Employee.LastName,
                            gender = user.Employee.Gender,
                            NPP = user.Employee.NPP,
                            PhoneNumber = user.Employee.PhoneNumber
                        }).ToList();
            return data;
        }
        #endregion
        #region Login Data VM
        public LoginDataVM TokenPayload(string npp)
        {
            var query = _connection.Query<AccountRoleVM>("EXEC SP_RolesList @Npp", new
            {
                Npp = npp
            }).ToList();

            List<string> roles = new List<string>();

            foreach (var item in query)
            {
                roles.Add(item.RoleName);
            }

            LoginDataVM payload = new LoginDataVM
            {
                AccountId = npp,
                Roles = roles

            };
            return payload;
        }
        #endregion
        #region Login
        public int Login(string npp, string password)
        {
            var checkData = (from acc in _context.Accounts
                             where acc.NPP == npp
                             select new
                             {
                                 acc.NPP,
                                 acc.Password
                             }).FirstOrDefault();

            if (checkData == null)
            {
                return 2; //Akun tidak ditemukan 
            }
            bool validPassword = BCrypt.Net.BCrypt.Verify(password, checkData.Password);
            if (!validPassword)
            {
                return 3; // Password salah
            }
            else
            {
                return 1; // Berhasil login
            }
        }
        #endregion

        public int RegisterAccount(RegisterAccountVM model)
        {
            Employee employee = new Employee
            {
                NPP = model.NPP,
                PhoneNumber = model.PhoneNumber,
                Gender = model.gender,
                Service = _context.Services.FirstOrDefault(s => s.Id == model.ServiceId),
                Position = _context.Positions.FirstOrDefault(p => p.Id == model.PositionId),
                CreateDate = DateTime.Now,
                FirstName = model.FirstName,
                LastName = model.LastName
            };
            _context.Employees.Add(employee);
            foreach (var item in model.roles!)
            {
                Role role = _context.Roles.FirstOrDefault(role => role.RoleName == item.RoleName)!;
                AccountRole accountRole = new AccountRole
                {
                    NPP = employee.NPP,
                    Role = role
                };
                _context.AccountRoles.Add(accountRole);

            }
            Account account = new Account
            {
                NPP = employee.NPP,
                UserName = employee.NPP,
                Password = BCrypt.Net.BCrypt.HashPassword("BNI" + employee.NPP, BCrypt.Net.SaltRevision.Revision2B),
            };
            _context.Accounts.Add(account);

            var result = _context.SaveChanges();
            return result;

        }
    }
}
