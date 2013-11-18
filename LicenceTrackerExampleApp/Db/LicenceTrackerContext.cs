using LicenceTracker.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace LicenceTracker.Db
{
    public class LicenceTrackerContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Software> SoftwareProducts { get; set; }
        public DbSet<SoftwareFile> SoftwareFiles { get; set; }
        public DbSet<LicenceAllocation> LicenceAllocations { get; set; }
        public DbSet<Licence> Licences { get; set; }
        public DbSet<SoftwareType> SoftwareTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //  Set up the Person table
            modelBuilder.Entity<Person>().Property(p => p.FirstName).HasMaxLength(20).IsRequired().IsVariableLength();
            modelBuilder.Entity<Person>().Property(p => p.LastName).HasMaxLength(20).IsRequired().IsVariableLength();

            //  Set up the SoftwareFile table
            modelBuilder.Entity<SoftwareFile>().Property(s => s.FileName).HasMaxLength(250).IsRequired().IsVariableLength();
            modelBuilder.Entity<SoftwareFile>().Property(s => s.FileType).IsRequired();            

            modelBuilder.Entity<Software>().ToTable("Software");
            modelBuilder.Entity<Software>().Property(s => s.Description).HasMaxLength(250).IsOptional().IsVariableLength();

            modelBuilder.Entity<SoftwareType>().Property(s => s.Description).HasMaxLength(250).IsOptional().IsVariableLength();
            modelBuilder.Entity<SoftwareType>().Property(s => s.Name).HasMaxLength(250).IsRequired().IsVariableLength();

            modelBuilder.Entity<Licence>().Property(l => l.LicenceKey).HasMaxLength(250).IsRequired().IsVariableLength();

            modelBuilder.Entity<LicenceAllocation>().Property(p => p.Id).HasColumnOrder(0);
            modelBuilder.Entity<LicenceAllocation>().Property(p => p.PersonId).HasColumnOrder(1);
            modelBuilder.Entity<LicenceAllocation>().Property(p => p.LicenceId).HasColumnOrder(2);
            modelBuilder.Entity<LicenceAllocation>().Property(p => p.StartDate).HasColumnOrder(3);
            modelBuilder.Entity<LicenceAllocation>().Property(p => p.EndDate).HasColumnOrder(4);

            base.OnModelCreating(modelBuilder);
        }
    }
}
