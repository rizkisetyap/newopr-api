using Microsoft.EntityFrameworkCore;
using My_OPR.Data;
using My_OPR.Models.Master;
using My_OPR.ViewModels;
using Microsoft.AspNetCore.Identity;

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

        public Employee Get(string npp)
        {
            var exist = _context.Employees.Include(e => e.Account).Include(x => x.Account.Roles).Include(x => x.Account.Roles).Where(x => x.NPP == npp).Include(x => x.Position).Include(s => s.Service).Include(s => s.Service.Group).FirstOrDefault();
            if (exist != null)
            {
                return exist;
            }
            throw new Exception("Data Not Found!");
        }

        public Employee Update(Employee employee)
        {
            var data = Get(employee.NPP);
            if (data != null)
            {
                string oldNpp = data.NPP;
                data.NPP = employee.NPP;
                data.FirstName = employee.FirstName;
                data.LastName = employee.LastName;
                data.Gender = employee.Gender;
                data.PhoneNumber = employee.PhoneNumber;
                data.PositionId = employee.PositionId;
                data.ServiceId = employee.ServiceId;
                _context.Entry(data).State = EntityState.Modified;

                Account account = _context.Accounts.Find(oldNpp);
                string password = "BNI" + employee.NPP;
                account.NPP = employee.NPP;
                account.UserName = employee.NPP;
                account.Password = BCrypt.Net.BCrypt.HashPassword(password);
                _context.Entry(account).State = EntityState.Modified;
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
    }
}
