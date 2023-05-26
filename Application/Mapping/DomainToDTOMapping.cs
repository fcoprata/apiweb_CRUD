using api_web.Domain.DTO;
using api_web.Domain.Model.EmployeeAggregate;
using AutoMapper;

namespace api_web.Application.Mapping
{
    public class DomainToDTOMapping : Profile
    {
        public DomainToDTOMapping()
        { 
            CreateMap<Employee, EmployeeDTO>()
                .ForMember(dest => dest.Name, m => m.MapFrom(orig => orig.name));
        }
    }
}
