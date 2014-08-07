using System.Data.Entity.ModelConfiguration;

namespace ExampleApplication.DataAccess.EF.Mapping
{
    public class TaskMap : EntityTypeConfiguration<Task>
    {
        public TaskMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(150);

            this.Property(t => t.Description)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("Task");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.ProjectId).HasColumnName("ProjectId");
            this.Property(t => t.Visible).HasColumnName("Visible");
            this.Property(t => t.Estimate).HasColumnName("Estimate");

            // Relationships
            this.HasRequired(t => t.Project)
                .WithMany(t => t.Tasks)
                .HasForeignKey(d => d.ProjectId);

        }
    }
}
