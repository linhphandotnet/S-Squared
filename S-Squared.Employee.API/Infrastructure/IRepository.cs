using S_Squared.EmployeeAPI.Models;

namespace S_Squared.EmployeeAPI.Infrastructure
{
    public interface IRepository<T> where T : Entity
    {
        Task<bool> SaveChangeAsync();
    }
}
