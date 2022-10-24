using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    public interface IEmployee
    {
        Guid Id { get; set; }

        string Name { get; set; }

        string LastName { get; set; }

        float Experience { get; set; }

        Address Address { get; set; }

        WorkerType WorkerType { get; set; }
    }
}
