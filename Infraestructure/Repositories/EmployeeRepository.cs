using api_web.Application.Mapping;
using api_web.Domain.DTO;
using api_web.Domain.Model.EmployeeAggregate;
using Microsoft.AspNetCore.Http.HttpResults;

namespace api_web.infraestrutura
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();
        public void Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public async Task<EmployeeDTO> Delete(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                return null;
            }
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            var responseDTO = new EmployeeDTO();
            responseDTO.Photo = employee.photo;
            responseDTO.Name = employee.name;
            responseDTO.Id = employee.id;
            return responseDTO;
        }

        public List<EmployeeDTO> Get(int pageNumber, int pageQuantity)
        {
            return _context.Employees.Skip(pageNumber * pageQuantity)
                .Take(pageQuantity)
                .Select(b =>
                new EmployeeDTO()
                {
                    Id = b.id,
                    Name = b.name,
                    Photo = b.photo
                }).ToList();
        }

        public Employee? Get(int id)
        {
            return _context.Employees.Find(id);
        }
    }
}
