using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectNugets.Support.Dtos
{
    public class SolutionProjectDto
    {
        public int Id { get; set; }
        public string SolutionName { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectPath { get; set; }
        public string NetVersion { get; set; }
        public bool IsNuget { get; set; }
    }
}
