using VolleyBizWebApi.Applications.Models;

namespace VolleyBizWebApi.Applications.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeViewModel>> GetAllEmployeeAsync();
        Task<EmployeeViewModel> GetEmployeeByIdAsync(int id);

        Task<int> AddEmployeeAsyn(EmployeeViewModel employeeView);
        Task<int> EditEmployeeAsync(EmployeeViewModel employeeView);
        Task<int> DeleteEmployeeAsync(int id);
    }
}
