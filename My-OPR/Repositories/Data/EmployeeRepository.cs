using Microsoft.EntityFrameworkCore;
using My_OPR.Data;
using My_OPR.Models.Master;
using My_OPR.ViewModels;

namespace My_OPR.Repositories.Data
{
    public class EmployeeRepository
    {
        private readonly ApplicationDBContext _context;
        public EmployeeRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public Employee Register(RegisterVM model)
        {
            var exist = _context.Employees.Find(model.Employee.NPP);
            if (exist != null)
            {
                throw new Exception("Data Already Exist!");
            }
            else
            {
                _context.Employees.Add(model.Employee);
                string password = "BNI" + model.Employee.NPP;
                Account account = new Account();
                account.NPP = model.Employee.NPP;
                account.UserName = model.Employee.NPP;
                account.Password = BCrypt.Net.BCrypt.HashPassword(password);
                // foreach (var role in model.Roles)
                // {
                //     var exists = _context.AccountRoles.FirstOrDefault(x => x.NPP == account.NPP && x.RoleId == role.Id);
                //     if (exist == null)
                //     {
                //         AccountRole accRole = new AccountRole() { NPP = account.NPP, RoleId = role.Id };
                //         _context.AccountRoles.Add(accRole);

                //     }

                // }
                _context.Accounts.Add(account);

                _context.SaveChanges();
                return model.Employee;
            }
            throw new Exception("Data Exist!");
        }

        public int ResetPassword(string npp)
        {
            var exist = _context.Accounts.Find(npp);
            if (exist != null)
            {
                string password = "BNI" + npp;
                exist.Password = BCrypt.Net.BCrypt.HashPassword(password);
                _context.Entry(exist).State = EntityState.Modified;
                int result = _context.SaveChanges();

                return result;
            }
            throw new Exception("Data Not Found!");
        }

        public List<Employee> GetAll()
        {
            return _context.Employees
            .Include(x => x.Service)
            .Include(x => x.Service.Group)
            .Include(x => x.Position)
                .OrderBy(x => x.FirstName)
                .Where(x => x.IsDelete == false).ToList();
        }

        public Employee Get(string? npp)

        {
            if (npp == null)
            {
                return null;
            }
            var exist = _context.Employees
                .Include(e => e.Account)
                .Include(x => x.Account.Roles)
                .Include(x => x.Position)
                .Include(s => s.Service)
                .Include(s => s.Service.Group)
                .Include(x => x.Service.Units)
                .Where(x => x.NPP == npp)
                .FirstOrDefault();
            if (exist != null)
            {
                return exist;
            }
            throw new Exception("Data Not Found!");
        }

        public Employee Update(UpdateEmployeeVM model)
        {
            var data = Get(model.Employee.NPP);
            if (data != null)
            {
                string oldNpp = data.NPP;
                data.NPP = model.Employee.NPP;
                data.FirstName = model.Employee.FirstName;
                data.LastName = model.Employee.LastName;
                data.Gender = model.Employee.Gender;
                data.PhoneNumber = model.Employee.PhoneNumber;
                data.PositionId = model.Employee.PositionId;
                data.ServiceId = model.Employee.ServiceId;
                data.GroupId = model.Employee.GroupId;
                data.DateOfBirth = model.Employee.DateOfBirth;
                _context.Entry(data).State = EntityState.Modified;

                Account account = _context.Accounts.Find(data.NPP);
                string password = "BNI" + model.Employee.NPP;
                account.NPP = model.Employee.NPP;
                account.UserName = model.Employee.NPP;
                account.Password = BCrypt.Net.BCrypt.HashPassword(password);
                _context.Entry(account).State = EntityState.Modified;
                List<AccountRole> accountRoles = _context.AccountRoles.Where(x => x.NPP == account.NPP).ToList();
                _context.RemoveRange(accountRoles);
                foreach (var item in model.roles!)
                {
                    Role role = _context.Roles.FirstOrDefault(role => role.RoleName == item.RoleName)!;
                    AccountRole accountRole = new AccountRole
                    {
                        NPP = account.NPP,
                        Role = role
                    };
                    _context.AccountRoles.Add(accountRole);

                }

                _context.SaveChanges();
                return data;
            }
            throw new Exception("Employee not exist");
        }

        public int Delete(string npp)
        {
            var data = Get(npp);
            if (data != null)
            {
                data.IsDelete = true;
                _context.Entry(data).State = EntityState.Modified;
                return _context.SaveChanges();
            }
            throw new Exception("Employee not found!");
        }
        // public IQueryable HBD()
        // {
        //     var today = DateTime.Now.ToShortDateString();
        //     return _context.Employees.Where(x => x.DateOfBirth.ToShortDateString() == today);
        // }
    }
}
