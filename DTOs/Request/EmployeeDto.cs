namespace EmployeeCrudAPI.DTOs.Request
{
    //Request DTOs ini digunakan untuk melakukan transfer
    //data berupa request yang kita inginkan pada aplikasi
    public class EmployeeDto
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
