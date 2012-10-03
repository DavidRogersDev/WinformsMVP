using System.Collections.Generic;
using System.Data.Objects;

namespace ExampleApplication.ExampleData
{
    public class TaskRepository : GenericRepository<Task>
    {
        public TaskRepository(ObjectContext context) : base(context)
        {
            
        }

        public void DeleteTasks(IList<Task> tasks)
        {
            for (int i = tasks.Count - 1; i > -1; i--)
            {
                Delete(tasks[i]);
            }
        }
    }
}
