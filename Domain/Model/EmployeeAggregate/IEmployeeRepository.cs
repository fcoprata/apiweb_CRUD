using api_web.Domain.DTO;

namespace api_web.Domain.Model.EmployeeAggregate
{
    public interface IEmployeeRepository
    {
        void Add(Employee employee);

        List<EmployeeDTO> Get(int pagenumber, int pageQuantity);

        Employee Get(int id);
    }
}
