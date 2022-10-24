using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dto
{
    public class OfficeWorkerDto
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public float Experience { get; set; }

        public Address Address { get; set; }

        public WorkerType WorkerType { get; set; }

        public OfficeStation OfficeStation { get; set; }

        public int Intelligence { get; set; }
    }
}
