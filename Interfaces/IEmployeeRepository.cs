using EmployeeCrudAPI.Models;

namespace EmployeeCrudAPI.Interfaces
{
    //Interface ini digunakan untuk melakukan constuctor antara
    //service dan repository
    public interface IEmployeeRepository
    {
        Task<Employee> GetByIdAsync(int employeeId);
        Task<IEnumerable<Employee>> GetAllAsync();
        Task AddAsync(Employee employee);
        Task UpdateAsync(Employee employee);
        Task DeleteAsync(int employeeId);
    }
}
