using System.Data.Entity.ModelConfiguration;

namespace ExampleApplication.DataAccess.EF.Mapping
{
    public class WorkMap : EntityTypeConfiguration<Work>
    {
        public WorkMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.description)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("Work");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.taskId).HasColumnName("taskId");
            this.Property(t => t.duration).HasColumnName("duration");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.dateOfWork).HasColumnName("dateOfWork");

            // Relationships
            this.HasRequired(t => t.Task)
                .WithMany(t => t.Works)
                .HasForeignKey(d => d.taskId);

        }
    }
}
