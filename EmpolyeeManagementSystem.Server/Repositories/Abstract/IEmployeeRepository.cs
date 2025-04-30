using EMS.API.DTOs;
using EMS.API.Models;
namespace EMS.API.Repositories.Abstract
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<PaginatedList<Employee>> GetPaginatedListAsync(int pageNumber, int pageSize);
        Task<Employee?> GetByIdAsync(int id);
        Task<Employee> AddAsync(Employee employee);
        Task UpdateAsync(Employee employee);
        Task DeleteAsync(Employee employee);

    }
}
