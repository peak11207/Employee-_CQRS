using AutoMapper;
using Employee__CQRS.DTOs;
using Employee__CQRS.Features.Employees.addEmployee;
using Employee__CQRS.Features.Employees.updateEmployee;
using Employee__CQRS.Models;

namespace Employee__CQRS.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap(); 
            CreateMap<addEmployeeCommand, Employee>();
            CreateMap<UpdateEmployeeCommand, Employee>()
            .ForMember(dest => dest.EmpNo, opt => opt.Ignore()) // ถ้าต้องการละเว้นการแมพ EmpNo
            .ForMember(dest => dest.HireDate, opt => opt.Ignore());
        }
    }
}
