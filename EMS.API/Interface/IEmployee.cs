using EMS.Models;

namespace EMS.API.Interface
{
    public interface IEmployee
    {
        CommonResponse GetEmployee();
        CommonResponse GetEmployeeById(int id);
        CommonResponse SaveEmployee(Employee employee);
        CommonResponse DeleteEmployee(int id);
        CommonResponse UpdateEmployee(Employee employee, int id);
        CommonResponse SearchEmployee(string searchText);
    }
}
