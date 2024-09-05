namespace EmployeeCrudAPI.Response
{
    //Response DTOs ini juga digunakan sebagai transfer
    //data untuk menampilkan response dari aplikasi yang kita inginkan
    public class EmployeeResponseDto
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
