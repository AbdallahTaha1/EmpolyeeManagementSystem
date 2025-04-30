using EMS.API.Data;
using EMS.API.Models;
using EMS.API.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Repositories.Implementation
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync() =>
            await _context.Employees
                           .AsNoTracking()
                           .ToListAsync();

        public async Task<Employee?> GetByIdAsync(int id) =>
            await _context.Employees
                      .AsNoTracking()
                      .FirstOrDefaultAsync(e => e.Id == id);


        public async Task<Employee> AddAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task UpdateAsync(Employee employee)
        {
            _context.Update(employee);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Employee employee)
        {
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }
    }
}
