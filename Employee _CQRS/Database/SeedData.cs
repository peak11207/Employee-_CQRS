using Employee__CQRS.Models;

namespace Employee__CQRS.Database
{
    public static class SeedData
    {
        public static void Initialize(AppDbContext context)
        {
            // ตรวจสอบว่ามีข้อมูลหรือไม่ถ้ามีไม่ต้องเพิ่ม
            if (context.Employees.Any())
            {
                return; 
            }

            // ข้อมูลTEST
            var employees = new List<Employee>
            {
                new Employee { EmpNo = 1001, FirstName = "STEFAN", LastName = "SALVATORE", Designation = "BUSINESS ANALYST", HireDate = new DateTime(1997, 11, 17), Salary = 50000, Comm = null, DeptNo = 40 },
                new Employee { EmpNo = 1003, FirstName = "JAMES", LastName = "MADINASON", Designation = "MANAGER", HireDate = new DateTime(1988, 06, 19), Salary = 84000, Comm = null, DeptNo = 30 },
                new Employee { EmpNo = 1004, FirstName = "JONES", LastName = "NICK", Designation = "HR ANALYST", HireDate = new DateTime(2003, 01, 02), Salary = 47000, Comm = null, DeptNo = 30 },
                new Employee { EmpNo = 1005, FirstName = "LUCY", LastName = "GELLER", Designation = "HR ASSOCIATE", HireDate = new DateTime(2008, 07, 13), Salary = 35000, Comm = 200, DeptNo = 30 },
                new Employee { EmpNo = 1006, FirstName = "ISAAC", LastName = "STEFAN", Designation = "TRAINEE", HireDate = new DateTime(2015, 12, 13), Salary = 20000, Comm = null, DeptNo = 40 },
                new Employee { EmpNo = 1007, FirstName = "JOHN", LastName = "SMITH", Designation = "CLERK", HireDate = new DateTime(2005, 12, 17), Salary = 12000, Comm = null, DeptNo = 10 },
                new Employee { EmpNo = 1008, FirstName = "NANCY", LastName = "GILLBERT", Designation = "SALESMAN", HireDate = new DateTime(1981, 02, 20), Salary = 1600, Comm = 300, DeptNo = 30 },
                new Employee { EmpNo = 1009, FirstName = "TEST", LastName = "TESTTT", Designation = "SALESMAN", HireDate = new DateTime(2005, 12, 21), Salary = 9000, Comm = 0, DeptNo = 100 },
                new Employee { EmpNo = 1010, FirstName = "JOHN", LastName = "JOHNJOHN", Designation = "MANAGER", HireDate = new DateTime(2024, 09, 06), Salary = 100000, Comm = 300, DeptNo = 20 }
            };

            context.Employees.AddRange(employees);
            context.SaveChanges();
        }
    }
}
