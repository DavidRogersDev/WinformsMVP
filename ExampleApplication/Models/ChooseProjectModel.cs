using System.Collections.Generic;
using ExampleApplication.DataAccess.EF;

namespace ExampleApplication.Models
{
    public class ChooseProjectModel
    {
        public IList<Project> Projects { get; set; }
    }
}
