using Microsoft.EntityFrameworkCore;
using My_OPR.Data;
using My_OPR.Repositories.Interface;

namespace My_OPR.Repositories
{
    public class GenericRepository<Context, Entity, Key> : IRepository<Entity, Key>
        where Entity : class
        where Context : ApplicationDBContext
    {
        private readonly ApplicationDBContext _context;
        private readonly DbSet<Entity> _entities;

        public GenericRepository(ApplicationDBContext context)
        {
            this._context = context;
            _entities = _context.Set<Entity>();
        }

        public virtual int Delete(Entity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            try
            {
                var obj = entity;
                _entities.Remove(entity);

                var result = _context.SaveChanges();
                return result;
            }
            catch
            {
                return 0;
            }
        }

        public virtual Entity Get(Key key)
        {
            var entity = _entities.Find(key);

            return entity;
        }

        public virtual IEnumerable<Entity> Get()
        {
            return _entities.ToList();
        }

        public virtual int Insert(Entity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            _entities.Add(entity);
            try
            {
                var result = _context.SaveChanges();
                return result;
            }
            catch (Exception)
            {

                return 0;
            }

        }

        public virtual int Update(Entity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            _context.Entry(entity).State = EntityState.Modified;
            try
            {
                var result = _context.SaveChanges();
                return result;
            }
            catch (Exception)
            {

                return 0;
            }
        }
    }
}
