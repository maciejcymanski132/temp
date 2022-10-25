using AutoMapper;
using Models.Dto;
using Models.WorkerModels;

namespace EmployeesAPI
{
    public class AutoMapperConfiguration : Profile
    {

        public AutoMapperConfiguration(){
            CreateMap<OfficeWorkerDto, OfficeWorker>();
            CreateMap<OfficeWorker, OfficeWorkerDto>();
        }
    }
}
