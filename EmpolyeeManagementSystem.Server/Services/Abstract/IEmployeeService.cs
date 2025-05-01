using EMS.API.DTOs;
using EMS.API.Models;

namespace EMS.API.Services.Abstract
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee?> GetByIdAsync(int id);
        Task<Employee> CreateAsync(Employee employee);
        Task UpdateAsync(Employee employee);
        Task DeleteAsync(int id);
        Task<PaginatedList<Employee>> GetPaginatedListAsync(int pageNumer, int pageSize, string? searchTerm);
    }
}
