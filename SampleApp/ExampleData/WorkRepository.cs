using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;

namespace SampleApp.ExampleData
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
