using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Orso.Arpa.Domain.Entities;
using Orso.Arpa.Domain.Interfaces;
using Orso.Arpa.Persistence.Configurations;

namespace Orso.Arpa.Persistence.DataAccess
{
    public class ArpaContext : IdentityDbContext<User, Role, Guid>, IArpaContext
    {
        private readonly ITokenAccessor _tokenAccessor;

        public ArpaContext(
            DbContextOptions options,
            ITokenAccessor tokenAccessor) : base(options)
        {
            _tokenAccessor = tokenAccessor;
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentParticipation> AppointmentParticipations { get; set; }
        public DbSet<AppointmentRoom> AppointmentRooms { get; set; }
        public DbSet<MusicianProfile> MusicianProfiles { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<PersonAddress> PersonAddresses { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectAppointment> ProjectAppointments { get; set; }
        public DbSet<ProjectParticipation> ProjectParticipations { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<SectionAppointment> SectionAppointments { get; set; }
        public DbSet<SelectValueCategory> SelectValueCategories { get; set; }
        public DbSet<SelectValue> SelectValues { get; set; }
        public DbSet<SelectValueMapping> SelectValueMappings { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Room> Rooms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (Type type in ArpaContextUtility.GetEntityTypes())

            {
                MethodInfo method = ArpaContextUtility.SetGlobalQueryMethod.MakeGenericMethod(type);
                method.Invoke(this, new object[] { builder });
            }

            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (EntityEntry<BaseEntity> entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Create(_tokenAccessor.DisplayName);
                        break;

                    case EntityState.Modified:
                        entry.Entity.Modify(_tokenAccessor.DisplayName);
                        break;

                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.Entity.Delete(_tokenAccessor.DisplayName);
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}