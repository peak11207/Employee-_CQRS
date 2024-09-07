using Employee__CQRS.Database;
using MediatR;

namespace Employee__CQRS.Features.Employees.deleteEmployee
{
    public record DeleteEmployeeCommand(int Id) : IRequest<bool>;
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        private readonly AppDbContext _context;

        public DeleteEmployeeHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FindAsync(request.Id);
            if (employee == null)
            { 
                return false; 
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
