using Microsoft.EntityFrameworkCore;
using My_OPR.Models.DocumentISO;
using My_OPR.Models.Master;
using My_OPR.Models.Transaction;
using My_OPR.Models.ZoomScheduler;

namespace My_OPR.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }


        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountRole> AccountRoles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<ExtUser> ExtUsers { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<ListApp> ListApps { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<OfficeLocation> officeLocations { get; set; }


        #region Transaction
        public DbSet<Content> Contents { get; set; }
        // public DbSet<LaporanHarian> LaporanHarians { get; set; }
        public DbSet<Presence> Presences { get; set; }
        #endregion
        #region document controller
        public DbSet<HistoryISO> HistoryISOs { get; set; }
        public DbSet<ISOCore> ISOCores { get; set; }
        // public DbSet<ISOSupport> ISOSupports { get; set; }
        public DbSet<RegisteredForm> RegisteredForms { get; set; }
        public DbSet<KategoriDocument> KategoriDocuments { get; set; }
        public DbSet<FileRegisteredIso> FileRegisteredIsos { get; set; }
        public DbSet<DetailRegister> DetailRegisters { get; set; }
        public DbSet<SubLayanan> Units { get; set; }
        public DbSet<JenisDocument> JenisDocuments { get; set; }
        #endregion
        #region Zoom
        public DbSet<Scheduler> Schedulers { get; set; }
        public DbSet<ZoomModel> Zooms { get; set; }
        public DbSet<ZoomStatus> ZoomStatuses { get; set; }
        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);
            #region Employee
            modelBuilder.Entity<Employee>().HasOne(e => e.Account)
                           .WithOne(e => e.Employee)
                           .HasForeignKey<Account>(e => e.NPP);

            modelBuilder.Entity<Employee>()
                .HasOne(s => s.Service)
                .WithMany(e => e.Employees)
                .HasForeignKey(s => s.ServiceId);

            modelBuilder.Entity<Employee>()
                .HasOne(p => p.Position)
                .WithMany(e => e.Employees)
                .HasForeignKey(p => p.PositionId);
            #endregion

            #region Account Role
            modelBuilder.Entity<AccountRole>()
                .HasOne(a => a.Account)
                .WithMany(ar => ar.Roles)
                .HasForeignKey(ar => ar.NPP);

            modelBuilder.Entity<AccountRole>()
                .HasOne(r => r.Role)
                .WithMany(ar => ar.AccountRoles)
                .HasForeignKey(ar => ar.RoleId);


            #endregion

            #region Presence
            modelBuilder.Entity<Presence>()
                .HasOne(e => e.Event)
                .WithMany(e => e.Presence)
                .HasForeignKey(e => e.EventId);

            modelBuilder.Entity<Presence>()
                .HasOne(e => e.Employee)
                .WithMany(e => e.Presences)
                .HasForeignKey(e => e.NPP);
            #endregion

            #region Document Controller ISO
            //relasi Iso Support to Registered Form
            modelBuilder.Entity<DetailRegister>()
                .HasOne(rg => rg.RegisteredForm)
                .WithMany(dr => dr.DetailRegisters)
                .HasForeignKey(rg => rg.RegisteredFormId);

            modelBuilder.Entity<FileRegisteredIso>()
            .HasOne(fl => fl.DetailRegister)
            .WithOne(dr => dr.FileRegisteredIso);

            modelBuilder.Entity<RegisteredForm>()
            .HasOne(rg => rg.JenisDokumen)
            .WithMany(kd => kd.RegisteredForms)
            .HasForeignKey(rg => rg.JenisDokumenId);

            // modelBuilder.Entity<KategoriDocument>()
            // .HasOne(kd => kd.RegisteredForms)
            // .WithOne(rg => rg.KategoriDocument);

            modelBuilder.Entity<RegisteredForm>()
                .HasOne(s => s.Service)
                .WithMany(reg => reg.RegisteredForms)
                .HasForeignKey(reg => reg.ServiceId);
            //history Iso
            // modelBuilder.Entity<HistoryISO>()
            //     .HasOne(i => i.ISOSupport)
            //     .WithMany(h => h.HistoryISOs)
            //     .HasForeignKey(h => h.IsoSupportId);

            #endregion

            #region Zoom Scheduler
            modelBuilder.Entity<Scheduler>()
                .HasOne(z => z.ZoomModel)
                .WithMany(s => s.Scheduler)
                .HasForeignKey(s => s.ZoomId);

            modelBuilder.Entity<Scheduler>()
                .HasOne(zs => zs.ZoomStatus)
                .WithMany(s => s.Schedulers)
                .HasForeignKey(s => s.ZoomStatusId);
            #endregion
            // #region  master
            // modelBuilder.Entity<Service>()
            // .HasOne(g => g.Group)
            // .WithMany(s => s.Services)
            // .HasForeignKey(s => s.GroupId);
            // #endregion
        }
    }
}
