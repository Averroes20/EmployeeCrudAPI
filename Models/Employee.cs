namespace EmployeeCrudAPI.Models
{
    //Model ini digunakan untuk pengolahan data kedalam
    //database
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
