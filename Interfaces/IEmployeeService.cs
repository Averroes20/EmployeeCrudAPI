using EmployeeCrudAPI.DTOs.Request;
using EmployeeCrudAPI.Response;

namespace EmployeeCrudAPI.Interfaces
{
    //Interface ini digunakan untuk melakukan constuctor antara
    //service dan repository
    public interface IEmployeeService
    {
        Task<EmployeeResponseDto> GetEmployeeAsync(int employeeId);
        Task<IEnumerable<EmployeeResponseDto>> GetEmployeesAsync();
        Task CreateEmployeeAsync(EmployeeDto employeeDto);
        Task UpdateEmployeeAsync(int employeeId,EmployeeDto employeeDto);
        Task DeleteEmployeeAsync(int employeeId);
    }
}
