using Microsoft.EntityFrameworkCore;
using My_OPR.Data;
using My_OPR.Models.Master;
using My_OPR.Models.Transaction;

namespace My_OPR.Repositories.Data
{
    public class EventRepository : GenericRepository<ApplicationDBContext, Event, int>
    {
        private readonly ApplicationDBContext _Context;
        public EventRepository(ApplicationDBContext context) : base(context)
        {
            _Context = context;
        }

        public List<Event> GetAll()
        {
            return _Context.Events.Where(x => x.IsDelete == false).OrderByDescending(x => x.CreateDate).ToList();
        }
        public List<Event> GetAllPublished()
        {
            return _Context.Events.Where(x => x.IsActive == true && x.IsDelete == false).OrderByDescending(x => x.CreateDate).ToList();
        }
        public Event GetActiveEvent(int id)
        {
            return _Context.Events.Where(x => x.IsDelete == false && x.IsActive == true && x.Id == id).FirstOrDefault();
        }

        public int SoftDelete(int id)
        {
            var data = _Context.Events.Find(id);
            if (data != null)
            {
                data.IsDelete = true;
                _Context.Entry(data).State = EntityState.Modified;
            }
            var result = _Context.SaveChanges();
            return result;
        }

        public int EventPresence(int eventId, string npp)
        {
            var eventExist = _Context.Events.Where(x => x.Id == eventId && x.IsDelete == false && x.IsActive == true).FirstOrDefault();
            if (eventExist == null)
            {
                throw new Exception("Event Not found or expired");
            }
            var isAlreadyPresence = _Context.Presences.Any(x => x.EventId == eventId && x.NPP == npp);
            if (isAlreadyPresence)
            {
                throw new Exception("Kamu sudah absen!!!");
            }
            var presence = new Presence();
            presence.CreateDate = DateTime.Now;
            presence.EventId = eventId;
            presence.NPP = npp;
            presence.IsInternal = true;
            _Context.Presences.Add(presence);
            var result = _Context.SaveChanges();
            return result;
        }

    }
}
