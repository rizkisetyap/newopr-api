using My_OPR.Data;
using My_OPR.Models.Master;
using Microsoft.EntityFrameworkCore;
namespace My_OPR.Repositories.Data
{
    public class ServiceRepository : GenericRepository<ApplicationDBContext, Service, int>
    {

        public readonly ApplicationDBContext _context;

        public ServiceRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;

        }
        public override IEnumerable<Service> Get()
        {
            return _context.Services.Include(x => x.Group).ToArray();
        }

        public async Task<int> DeleteById(int id)
        {
            var entity = await _context.Services.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                return 404;
            }
            _context.Remove(entity);
            try
            {
                await _context.SaveChangesAsync();
                return 200;
            }
            catch (System.Exception)
            {

                return 500;
            }
        }

        public List<Service> GetAll()
        {
            return _context.Services.Include(x => x.Group).Where(x => x.IsDelete == false).ToList();
        }

        public int SoftDelete(int id)
        {
            var data = _context.Services.Find(id);
            if (data != null)
            {
                data.IsDelete = true;
                _context.Entry(data).State = EntityState.Modified;
            }
            var result = _context.SaveChanges();
            return result;
            // var data = _context.Positions.Find(id);
            // if (data == null)
            // {
            //     return 404;
            // }
            // _context.Remove(data);
            // try (data != null)
            // {
            //     data.IsDelete = true;
            //     _context.Entry(data).State = EntityState.Modified;
            //     var result = _context.SaveChanges();
            //     return result;
            // }
            // catch (SystemException)
            // {
            //     return 500;
            // }            

        }
        public IQueryable GetByGroup(int? GroupId)
        {
            var result = _context.Services.Where(x => x.GroupId == GroupId);
            var file = _context.FileRegisteredIsos
            .Include(x => x.DetailRegister)
            .Include(x => x.DetailRegister.RegisteredForm)
            .Include(x => x.DetailRegister.RegisteredForm.Group)
            .Select(x => new
            {
                Name = x.DetailRegister.RegisteredForm.Group.GroupName,
            });

            return result;
        }
        public IQueryable GetServices()
        {
            var getall = _context.Services.Where(x => x.IsDelete == false).Select(x => new
            {
                Name = x.Name,
                Id = x.Id
            });

            return getall;
        }
    }
}
