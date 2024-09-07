using AutoMapper;
using Employee__CQRS.Database;
using Employee__CQRS.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Employee__CQRS.Features.Employees.getEmployee
{
    public record GetAllEmployeesQuery : IRequest<List<EmployeeDto>>;
    public class GetAllEmployeesHandler : IRequestHandler<GetAllEmployeesQuery, List<EmployeeDto>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetAllEmployeesHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<EmployeeDto>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = await _context.Employees.ToListAsync(cancellationToken);
            return _mapper.Map<List<EmployeeDto>>(employees);
        }
    }
}
