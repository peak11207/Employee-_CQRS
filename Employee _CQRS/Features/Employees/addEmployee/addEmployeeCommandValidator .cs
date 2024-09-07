using FluentValidation;

namespace Employee__CQRS.Features.Employees.addEmployee
{
    public class addEmployeeCommandValidator : AbstractValidator<addEmployeeCommand>
    {
        public addEmployeeCommandValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Designation).NotEmpty().MaximumLength(100);
            RuleFor(x => x.HireDate).NotEmpty();
            RuleFor(x => x.Salary).GreaterThan(0);
            RuleFor(x => x.DeptNo).NotEmpty();
        }
    }
}
