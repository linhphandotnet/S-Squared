namespace S_Squared.EmployeeClient.Services
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetEmployeesAsync();
        Task<List<Employee>> GetEmployeesByManagerAsync(int? managerId);
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<Employee> GetEmployeeByIdAsync(string id);
        Task<List<Employee>> GetManagersAsync();
        Task<bool> IsEmployeeExisted(string employeeId);
        Task<bool> CreateEmployee(Employee employee);
        Task<bool> UpdateEmployee(Employee employee);
        Task<bool> DeleteEmployee(int id);
    }
}
