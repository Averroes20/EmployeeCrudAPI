using EmployeeCrudAPI.DTOs.Request;
using EmployeeCrudAPI.Interfaces;
using EmployeeCrudAPI.Models;
using EmployeeCrudAPI.Response;

namespace EmployeeCrudAPI.Services
{
    //Service inilah yang menjadi inti untuk menyimpan
    //logika bisnis dalam aplikasi yang kita kembangkan
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<EmployeeResponseDto> GetEmployeeAsync(int employeeId)
        {
            try
            {
                var employee = await _employeeRepository.GetByIdAsync(employeeId);
                if (employee == null)
                {
                    return null;
                }

                return new EmployeeResponseDto
                {
                    EmployeeId = employee.EmployeeId,
                    FullName = employee.FullName,
                    BirthDate = employee.BirthDate,
                };
            }
            catch (Exception err)
            {
                throw new Exception("Data ID tidak ditemukan", err);
            }
        }

        public async Task<IEnumerable<EmployeeResponseDto>> GetEmployeesAsync()
        {
            try
            {
                var employees = await _employeeRepository.GetAllAsync(); ;
                return employees.Select(e => new EmployeeResponseDto
                {
                    EmployeeId = e.EmployeeId,
                    FullName = e.FullName,
                    BirthDate = e.BirthDate,
                });
            }
            catch (Exception err)
            {
                throw new Exception("Error saat menampilkan data");
            }
        }

        public async Task CreateEmployeeAsync(EmployeeDto employeeDto)
        {
            try
            {
                //Null Handling
                if (string.IsNullOrEmpty(employeeDto.FullName))
                    throw new ArgumentException(nameof(Employee.FullName), "FullName tidak boleh kosong!");

                //Date handling
                if (employeeDto.BirthDate > DateTime.Now)
                    throw new ArgumentException("Tanggal lahir tidak boleh diambil lebih dari hari ini");

                //Duplicate Handling
                var existingEmployee = (await _employeeRepository.GetAllAsync())
                    .FirstOrDefault(e => e.FullName.Equals(employeeDto.FullName, StringComparison.OrdinalIgnoreCase));

                if (existingEmployee != null)
                    throw new InvalidOperationException("Nama sudah terdaftar");

                //Create new Employee entity
                var employee = new Employee
                {
                    FullName = employeeDto.FullName,
                    BirthDate = employeeDto.BirthDate,
                };
                await _employeeRepository.AddAsync(employee);
            }
            catch (Exception err)
            {
                throw new Exception("Error creating employee", err);
            }
        }

        public async Task UpdateEmployeeAsync(int employeeId, EmployeeDto employeeDto)
        {
            try
            {
                var employee = await _employeeRepository.GetByIdAsync(employeeId);
                if (employee == null)
                {
                    throw new KeyNotFoundException("Employee Not Found");
                }

                //Null Handling
                if (string.IsNullOrEmpty(employeeDto.FullName))
                    throw new ArgumentNullException(nameof(Employee.FullName), "Fullname tidak boleh kosong");

                //Date Handling
                if (employeeDto.BirthDate > DateTime.Now)
                    throw new ArgumentException("Tanggal lahir tidak boleh diambil lebih dari hari ini", nameof(employeeDto.BirthDate));

                //Duplicate Handling (Sesuai dengan FullName)
                var existingEmployee = (await _employeeRepository.GetAllAsync())
                    .FirstOrDefault(e => e.FullName.Equals(employeeDto.FullName, StringComparison.OrdinalIgnoreCase) && e.EmployeeId != employeeId);

                if (existingEmployee != null)
                    throw new InvalidOperationException("Employee dengan nama yang dimasukkan sudah terdaftar");

                //Update employee fields
                employee.FullName = employeeDto.FullName;
                employee.BirthDate = employeeDto.BirthDate;

                await _employeeRepository.UpdateAsync(employee);
            }
            catch (Exception err)
            {
                throw new Exception("Error update employee", err);
            }
        }

        public async Task DeleteEmployeeAsync(int employeeId)
        {
            try
            {
                var employee = await _employeeRepository.GetByIdAsync(employeeId);
                if (employee == null)
                    throw new KeyNotFoundException("Employee not found");

                await _employeeRepository.DeleteAsync(employeeId);
            }
            catch (Exception err)
            {
                throw new Exception("Error deleting employee", err);
            }
        }
    }
}
