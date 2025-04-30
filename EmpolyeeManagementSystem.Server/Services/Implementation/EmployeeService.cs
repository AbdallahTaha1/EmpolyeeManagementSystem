using EMS.API.DTOs;
using EMS.API.Models;
using EMS.API.Repositories.Abstract;
using EMS.API.Services.Abstract;

namespace EMS.API.Services.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<IEnumerable<Employee>> GetAllAsync() =>
             await _employeeRepository.GetAllAsync();

        public async Task<Employee?> GetByIdAsync(int id) =>
             await _employeeRepository.GetByIdAsync(id);

        public async Task<PaginatedList<Employee>> GetPaginatedListAsync(int pageNumer, int pageSize) =>
            await _employeeRepository.GetPaginatedListAsync(pageNumer, pageSize);

        public async Task<Employee> CreateAsync(Employee employee)
        {
            return await _employeeRepository.AddAsync(employee);
        }
        public async Task UpdateAsync(Employee employee)
        {
            var existing = await _employeeRepository.GetByIdAsync(employee.Id);

            if (existing == null)
                throw new KeyNotFoundException($"Employee with ID {employee.Id} not found.");

            existing.FirstName = employee.FirstName;
            existing.LastName = employee.LastName;
            existing.Email = employee.Email;
            existing.Position = employee.Position;

            await _employeeRepository.UpdateAsync(employee);
        }

        public async Task DeleteAsync(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);

            if (employee == null)
                throw new KeyNotFoundException($"Employee with ID {id} not found.");

            await _employeeRepository.DeleteAsync(employee);
        }

    }
}
