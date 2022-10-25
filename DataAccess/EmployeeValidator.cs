using Models;
using Models.Dto;
using Models.Interfaces;
using Models.WorkerModels;

namespace DataProvider
{
    public class EmployeeValidator
    {
        public bool ValidateEmployee(EmployeeDto employee) {
            switch (employee.WorkerType)
            {
                case WorkerType.OfficeWorker:
                    if (employee.Commission != null || employee.Strength != null || employee.Efficiency != null || employee.Intelligence == null || employee.OfficeStation == null)
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
                case WorkerType.Merchant:
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
    }
}