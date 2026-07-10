using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectNugets.Support.Dtos
{
    public class ProjectDto
    {
        public int Id { get; set; }
        public int SolutionId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectPath { get; set; }
        public string NetVersion { get; set; }
        public bool IsNuget { get; set; }
    }
}
