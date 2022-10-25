using AutoMapper;
using AutoMapper.Configuration.Annotations;
using Models.Dto;
using Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Models.WorkerModels
{

    public class OfficeWorker : Employee
    {

        [Required]
        public Guid OfficeStation { get; set; }

        public int Intelligence { get; set; }

        public OfficeWorker(Guid id, string name, string lastname, int age, float experience, Address address, WorkerType workertype, int intelligence, Guid officeStation) : base(id, name, lastname, age, experience, address, workertype)
        {
            this.Intelligence = intelligence;
            this.OfficeStation = officeStation;
        }

    }
}
