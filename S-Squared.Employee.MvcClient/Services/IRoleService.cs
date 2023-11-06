namespace S_Squared.EmployeeClient.Services
{
    public interface IRoleService
    {
        Task<List<Role>> GetRolesAsync();
    }
}
