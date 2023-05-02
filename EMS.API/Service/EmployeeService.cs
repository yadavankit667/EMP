using EMS.API.DataContext;
using EMS.API.Interface;
using EMS.Models;

namespace EMS.API.Service
{
    public class EmployeeService : IEmployee
    {
        private readonly AppDbContext context;

        public EmployeeService(AppDbContext context)
        {
            this.context = context;
        }
        public CommonResponse DeleteEmployee(int id)
        {
            var commonResponse = new CommonResponse();
            try
            {
                //var data = context.Employees.Find(id);
                var data = (from emp in context.Employees
                            where emp.Id == id
                            select emp).FirstOrDefault();
                if (data != null)
                {
                    context.Remove(data);
                    context.SaveChanges();
                    commonResponse.IsSuccess = true;
                    commonResponse.Message = "Employee Deleted Successfully";
                }
                else
                {
                    commonResponse.IsSuccess = false;
                    commonResponse.Message = "Employee Not Found!";
                }
            }
            catch (Exception ex)
            {
                commonResponse.IsSuccess = false;
                commonResponse.Message = ex.Message;
            }
            return commonResponse;
        }

        public CommonResponse GetEmployee()
        {
            var response = new CommonResponse();
            try
            {
                //var list = context.Employees.ToList();

                var list = (from emp in context.Employees select emp).ToList();

                response.Result = list;
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public CommonResponse GetEmployeeById(int id)
        {
            var response = new CommonResponse();
            try
            {
                //var data = context.Employees.Find(id);
                var data = (from g in context.Employees
                            where g.Id == id
                            select g).FirstOrDefault();
                if (data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Employee Found Successfully";
                    response.Result = data;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Employee Not Found!";
                    response.Result = null;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public CommonResponse SaveEmployee(Employee employee)
        {
            var response = new CommonResponse();
            try
            {
                context.Add(employee);
                context.SaveChanges();

                response.Message = "Employee Added Successfully";
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public CommonResponse UpdateEmployee(Employee employee, int id)
        {
            var response = new CommonResponse();
            try
            {
                //var employeeData = context.Employees.Find(employee.Id);
                var employeeData = (from emp in context.Employees
                                    where emp.Id == id
                                    select emp).FirstOrDefault();
                if (employeeData != null)
                {
                    employeeData.Name = employee.Name;
                    employeeData.DOB = employee.DOB;
                    employeeData.Department = employee.Department;
                    employeeData.Email = employee.Email;

                    context.Update(employeeData);
                    context.SaveChanges();
                    response.IsSuccess = true;
                    response.Message = "Employee Updated Successfully";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Employee Not Found!";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public CommonResponse SearchEmployee(string searchText)
        {
            var response = new CommonResponse();
            try
            {
                var employees = (from st in context.Employees
                                 where (st.Name.Trim().ToLower().Contains(searchText.Trim().ToLower()) || (string.IsNullOrEmpty(searchText) && st.Name != null))
                                 || (st.Email.Trim().ToLower().Contains(searchText.Trim().ToLower()) || (string.IsNullOrEmpty(searchText) && st.Email != null))
                                 || (st.Department.Trim().ToLower().Contains(searchText.Trim().ToLower()) || (string.IsNullOrEmpty(searchText) && st.Department != null))
                                 select st).ToList();

                response.Result = employees;
                response.IsSuccess = true;
                response.Message = "Employees Found Successfully";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message; 
            }
            return response;
        }
    }
}
