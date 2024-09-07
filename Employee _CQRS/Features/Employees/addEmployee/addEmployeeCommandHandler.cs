using AutoMapper;
using Employee__CQRS.Database;
using Employee__CQRS.Models;
using MediatR;

namespace Employee__CQRS.Features.Employees.addEmployee
{
    public record addEmployeeCommand(string FirstName, string LastName, string Designation, DateTime HireDate, float Salary, int Comm, int DeptNo) : IRequest<int>;

    public class addEmployeeCommandHandler : IRequestHandler<addEmployeeCommand, int>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public addEmployeeCommandHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> Handle(addEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = _mapper.Map<Employee>(request);
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync(cancellationToken);

            return employee.EmpNo;
        }
    }
}
