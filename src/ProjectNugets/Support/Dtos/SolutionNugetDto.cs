using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectNugets.Support.Dtos
{
    public class SolutionNugetDto
    {
        public string SolutionName { get; set; }
        public string ProjectName { get; set; }
        public string NetVersion { get; set; }
        public bool IsNuget { get; set; }
        public string NugetName { get; set; }
        public string NugetPath { get; set; }
        public string NugetVersion { get; set; }
    }
}
