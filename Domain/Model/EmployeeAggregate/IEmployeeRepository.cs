using api_web.Domain.DTO;

namespace api_web.Domain.Model.EmployeeAggregate
{
    public interface IEmployeeRepository
    {
        // post
        void Add(Employee employee);

        // get all
        List<EmployeeDTO> Get(int pagenumber, int pageQuantity);

        // get id
        Employee Get(int id);

        // delete
        Task<EmployeeDTO> Delete(int id);
    }
}
