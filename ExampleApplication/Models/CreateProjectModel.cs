using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExampleApplication.Models
{
    public class CreateProjectModel
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public bool Visibilty { get; set; }
    }
}
