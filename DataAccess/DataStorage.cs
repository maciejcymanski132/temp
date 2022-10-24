using Models;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService
{
    public class DataStorage
    {
        public ICollection<IEmployee> Employees;

        public ICollection<OfficeStation> OfficeStations;

        public DataStorage()
        {
            this.Employees = new List<IEmployee>();
            this.OfficeStations = new List<OfficeStation>();
        }
    }
}
