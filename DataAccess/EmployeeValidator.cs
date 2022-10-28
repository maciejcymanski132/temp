using DataAccess.Interfaces;
using DataService;
using Models;
using Models.Dto;
using Models.WorkerModels;

namespace DataProvider
{
    public class EmployeeValidator
    {
        public bool ValidateEmployee(EmployeeDto employee, List<OfficeStation> stations) {
            switch (employee.WorkerType)
            {
                case WorkerType.OfficeWorker:
                    if (employee.Commission != null || employee.Strength != null || employee.Efficiency != null || employee.Intelligence == null || employee.OfficeStation == null || !this.StationAvailable((Guid)employee.OfficeStation, stations))
                    {
                        throw new ArgumentException("Invalid properties for office worker");
                    }
                    break;
                case WorkerType.PhysicalWorker:
                    if (employee.Commission != null || employee.Strength == null || employee.Efficiency != null || employee.Intelligence != null || employee.OfficeStation != null)
                    {
                        throw new ArgumentException("Invalid properties for physical worker");
                    }
                    break;
                case WorkerType.Trader:
                    if (employee.Commission == null || employee.Strength != null || employee.Efficiency == null || employee.Intelligence != null || employee.OfficeStation != null)
                    {
                        throw new ArgumentException("Invalid properties for trader");
                    }
                    break;
                default:
                    return false;
            }
            return true; 
        }

        public bool StationAvailable(Guid officeStationId, List<OfficeStation> stations)
        {
            var station = stations.FirstOrDefault(s => s.Id == officeStationId);
            if (station == null)
                throw new ArgumentException("Station doesn't exist");
            if (station?.AssignedEmployee != Guid.Empty)
                throw new ArgumentException("Station is already assigned");
            return true;
        }
    }
}