using AutoMapper;
using Employee__CQRS.Database;
using MediatR;

namespace Employee__CQRS.Features.Employees.updateEmployee
{
    public record UpdateEmployeeCommand(int EmpNo,string FirstName, string LastName, string Designation, DateTime HireDate, float Salary, int Comm, int DeptNo) : IRequest<bool>;
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand, bool>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UpdateEmployeeHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FindAsync(request.EmpNo);
            if (employee == null)
            {
                return false;
            };

            _mapper.Map(request, employee); 
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
