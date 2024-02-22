
namespace S_Squared.Data.Infrastructure
{
    public interface IRoleRepository : IRepository<Role>
    {
        Task<Role> GetById (int id);
        Task<Role> GetByName (string name);
        Task<List<Role>> GetAll();

        void CreateRole(Role role);
        void UpdateRole(Role role);
        bool DeleteRole(int id);
    }
}
