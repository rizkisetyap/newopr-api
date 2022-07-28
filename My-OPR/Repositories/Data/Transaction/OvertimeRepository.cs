using Microsoft.EntityFrameworkCore;
using My_OPR.Data;
using My_OPR.Models.Transaction;
using My_OPR.Repositories.Interface;
namespace My_OPR.Repositories.Data.Transaction
{
    public class OvertimeRepository : IRepository<Overtime, Guid>
    {
        private readonly ApplicationDBContext _context;
        public OvertimeRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Overtime> Get()
        {
            return _context.Overtimes.Where(x => x.IsDelete == false).ToArray();
        }
        public Overtime Get(Guid Id)
        {
            var data = _context.Overtimes
                .Include(x => x.User)
                .Include(x => x.Approval)
                .Where(x => x.Id == Id && x.IsDelete == false)
                .FirstOrDefault();
            if (data == null)
            {
                throw new Exception("Data not found");
            }
            return data;
        }
        public int Insert(Overtime model)
        {
            if (model == null) throw new Exception("Invalid data");
            _context.Add(model);
            return _context.SaveChanges();


        }
        public int Update(Overtime model)
        {
            if (model == null) throw new Exception("Data is null");
            _context.Entry(model).State = EntityState.Modified;
            return _context.SaveChanges();
        }
        public int Delete(Overtime overtime)
        {
            if (overtime == null) throw new Exception("Data is null");
            _context.Remove(overtime);

            return _context.SaveChanges();
        }
        public IQueryable GetApproval(int GroupId)
        {
            // P id = 5 : Pimkel
            // P id = 6 : Pengelola
            var appovals = _context.Employees
                .Include(x => x.Service)
                .Where(x => (x.PositionId == 5 || x.PositionId == 6) && x.Service.GroupId == GroupId)
                .Select(x => new
                {
                    npp = x.NPP,
                    Nama = x.FirstName + " " + x.LastName,
                    Jabatan = x.Position.PositionName
                });

            return appovals;
        }
        public OvertimeDetail RegisterOvertime(Overtime model)
        {
            _context.Add(model);
            _context.SaveChanges();

            OvertimeDetail Details = new OvertimeDetail();
            Details.OvertimeId = model.Id;
            Details.RequesterId = model.UserId;
            Details.RequestOvertimeStatusId = 1;
            Details.TanggalApprove = null;
            _context.Add(Details);
            _context.SaveChanges();

            return Details;
        }
        public IQueryable GetDetail(string npp)
        {
            var details = _context.OvertimeDetails
                .Include(x => x.Requester)
                .Include(x => x.RequestOvertimeStatus)
                .Include(x => x.Overtime)
                .Include(x => x.Overtime.Approval)
                .Where(x => x.Overtime.IsDelete == false && x.RequesterId == npp)
                .Select(x => new
                {
                    Id = x.Id,
                    Tanggal = x.Overtime.Tanggal,
                    Mulai = x.Overtime.JamMulai,
                    Selesai = x.Overtime.JamSelesai,
                    Approval = x.Overtime.Approval.FirstName + "" + x.Overtime.Approval.LastName,
                    Status = x.RequestOvertimeStatus.Name,
                    Catatan = x.Catatan,
                    Keterangan = x.Overtime.Alasan,
                    StatusId = x.RequestOvertimeStatusId
                });

            return details;
        }
        public List<OvertimeDetail> GetToApprove(int GroupId)
        {
            var listSurat = _context.OvertimeDetails
                .Include(x => x.Overtime)
                .Include(x => x.Requester)
                .Include(x => x.Requester.Service)
                .Where(x => x.Overtime.IsDelete == false && x.RequestOvertimeStatusId == 1 && x.Requester.Service.GroupId == GroupId)
                .ToList();

            return listSurat;
        }
    }
}
