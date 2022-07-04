using Microsoft.EntityFrameworkCore;
using My_OPR.Data;
using My_OPR.Models.Master;

namespace My_OPR.Repositories.Data
{
    public class GroupRepository : GenericRepository<ApplicationDBContext, Group, int>
    {
        private readonly ApplicationDBContext _context;
        public GroupRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }

        public List<Group> GetAll()
        {
            return _context.Groups.Where(x => x.IsDelete == false).ToList();
        }

        public int SoftDelete(int id)
        {
            var data = _context.Groups.Find(id);
            if (data != null)
            {
                data.IsDelete = true;
                _context.Entry(data).State = EntityState.Modified;
            }
            var result = _context.SaveChanges();
            return result;
        }

        public int BatchDelete(List<Group> groups)
        {
            try
            {
                List<Group> result = new List<Group>();
                foreach (var group in groups)
                {
                    result.Add(new Group { Id = group.Id });
                }
                _context.Groups.RemoveRange(result);
                return _context.SaveChanges();
            }
            catch (Exception)
            {

                return 0;
            }
        }
    }
}
