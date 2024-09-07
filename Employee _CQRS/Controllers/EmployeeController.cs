using Employee__CQRS.Database;
using Employee__CQRS.DTOs;
using Employee__CQRS.Features.Employees.addEmployee;
using Employee__CQRS.Features.Employees.deleteEmployee;
using Employee__CQRS.Features.Employees.getEmployee;
using Employee__CQRS.Features.Employees.updateEmployee;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee__CQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly AppDbContext _context;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployeeDto>>> GetAll()
        {
            var employees = await _mediator.Send(new GetAllEmployeesQuery());
            if (employees == null)
            {
                return NotFound();
            }
            return Ok(employees);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> GetById(int id)
        {
            var employee = await _mediator.Send(new GetEmployeeByIdQuery(id));
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
        [HttpPost]
        public async Task<ActionResult<int>> Create(addEmployeeCommand command)
        {

            var employeeId = await _mediator.Send(command);
            return Ok(employeeId);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> Update(int id, UpdateEmployeeCommand command)
        {
            if (id != command.EmpNo)
            {
                return BadRequest("ID mismatch");
            }
            var result = await _mediator.Send(command);
            if (!result)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteEmployeeCommand(id));
            if (!result) 
            { 
                return NotFound();
            }
            return Ok(result);
        }

    }
}
