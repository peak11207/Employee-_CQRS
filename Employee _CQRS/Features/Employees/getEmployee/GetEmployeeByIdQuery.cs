using AutoMapper;
using Employee__CQRS.Database;
using Employee__CQRS.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Employee__CQRS.Features.Employees.getEmployee
{
    public record GetEmployeeByIdQuery(int Id) : IRequest<EmployeeDto>;
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeDto>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetEmployeeByIdHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<EmployeeDto> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FindAsync(request.Id);
          
            return employee != null ? _mapper.Map<EmployeeDto>(employee) : null;
        }
    }
}
