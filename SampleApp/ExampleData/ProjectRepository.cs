using System.Data.Objects;

namespace SampleApp.ExampleData
{
    public class ProjectRepository : GenericRepository<Project>
    {
        public ProjectRepository(ObjectContext context) : base(context)
        {
        }
    }
}
