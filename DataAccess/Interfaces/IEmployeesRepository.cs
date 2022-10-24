using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IEmployeesRepository
    {
        public IEnumerable<IEmployee> GetAllEmployees();

        public IEmployee? GetEmployee(Guid Id);

        public int RemoveEmployee(Guid Id);

    }
}
