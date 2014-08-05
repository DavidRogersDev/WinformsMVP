using System.Data.Entity;
using ExampleApplication.DataAccess.EF.Mapping;


namespace ExampleApplication.DataAccess.EF
{
    public partial class TimetrackerContext : DbContext
    {
        static TimetrackerContext()
        {
            Database.SetInitializer<TimetrackerContext>(null);
        }

        public TimetrackerContext()
            : base("Name=TimetrackerContext")
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Work> Works { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProjectMap());
            modelBuilder.Configurations.Add(new TaskMap());
            modelBuilder.Configurations.Add(new WorkMap());
        }
    }
}
