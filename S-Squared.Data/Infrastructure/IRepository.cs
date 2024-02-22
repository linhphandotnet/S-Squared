
namespace S_Squared.Data.Infrastructure
{
    public interface IRepository<T> where T : Entity
    {
        Task<bool> SaveChangeAsync();
    }
}
