namespace Employee__CQRS.Models
{
    public class Employee
    {
        public int EmpNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
        public DateTime HireDate { get; set; }
        public float Salary { get; set; }
        public int? Comm { get; set; }
        public int DeptNo { get; set; }
    }
}
