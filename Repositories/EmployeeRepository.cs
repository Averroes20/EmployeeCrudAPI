using EmployeeCrudAPI.Data;
using EmployeeCrudAPI.Interfaces;
using EmployeeCrudAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCrudAPI.Repositories
{
    //Repository ini digunakan untuk membuat manipulasi
    //data kedalam database nantinya
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _appDbContext;

        private static int _currentId = 1000;

        public EmployeeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(Employee employee)
        {
            _currentId++;
            employee.EmployeeId = _currentId;

            Console.WriteLine($"Generated EmployeeId: {employee.EmployeeId}");  // Tambahkan ini untuk memeriksa nilai ID

            _appDbContext.Employees.Add(employee);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Employee> GetByIdAsync(int employeeId)
        {
            return await _appDbContext.Employees.FindAsync(employeeId);
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _appDbContext.Employees.ToListAsync();
        }

        /*public async Task AddAsync(Employee employee)
        {
            _appDbContext.Employees.Add(employee);
            await _appDbContext.SaveChangesAsync();
        }*/

        public async Task UpdateAsync(Employee employee)
        {
            _appDbContext.Employees.Update(employee);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int employeeId)
        {
            var employee = await _appDbContext.Employees.FindAsync(employeeId);
            if(employee != null)
            {
                _appDbContext.Employees.Remove(employee);
                await _appDbContext.SaveChangesAsync();
            }
        }
    }
}
