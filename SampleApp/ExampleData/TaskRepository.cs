using System.Data.Objects;

namespace SampleApp.ExampleData
{
    public class TaskRepository : GenericRepository<Task>
    {
        public TaskRepository(ObjectContext context) : base(context)
        {
            
        }
    }
}
