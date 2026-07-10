using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectNugets.Support.Dtos
{
    public class NugetDto
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string NugetName { get; set; }
        public string NugetPath { get; set; }
        public string NugetVersion { get; set; }
    }
}
