using System.Data.Entity.ModelConfiguration;

namespace ExampleApplication.DataAccess.EF.Mapping
{
    public class WorkMap : EntityTypeConfiguration<Work>
    {
        public WorkMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Description)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("Work");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.TaskId).HasColumnName("TaskId");
            this.Property(t => t.Duration).HasColumnName("Duration");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.DateOfWork).HasColumnName("DateOfWork");

            // Relationships
            this.HasRequired(t => t.Task)
                .WithMany(t => t.Works)
                .HasForeignKey(d => d.TaskId);

        }
    }
}
