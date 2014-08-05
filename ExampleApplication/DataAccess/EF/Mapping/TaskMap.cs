using System.Data.Entity.ModelConfiguration;

namespace ExampleApplication.DataAccess.EF.Mapping
{
    public class TaskMap : EntityTypeConfiguration<Task>
    {
        public TaskMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.name)
                .IsRequired()
                .HasMaxLength(150);

            this.Property(t => t.description)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("Task");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.projectId).HasColumnName("projectId");
            this.Property(t => t.visible).HasColumnName("visible");
            this.Property(t => t.estimate).HasColumnName("estimate");

            // Relationships
            this.HasRequired(t => t.Project)
                .WithMany(t => t.Tasks)
                .HasForeignKey(d => d.projectId);

        }
    }
}
