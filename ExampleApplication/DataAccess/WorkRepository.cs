using System.Collections.Generic;
using System.Data.Objects;

namespace ExampleApplication.DataAccess
{
    public class WorkRepository : GenericRepository<Work>
    {
        public WorkRepository(ObjectContext context) : base(context)
        {
        }

        public void DeleteWorkItems(IList<Work> works)
        {
            for(int i = works.Count - 1; i > -1; i--)
            {
                Delete(works[i]);
            }
        }
    }
}
