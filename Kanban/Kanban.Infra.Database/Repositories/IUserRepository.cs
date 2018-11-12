using Kanban.Shared.Domain;

namespace Kanban.Infra.Database.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
         User FindByEmail(string email);
    }
}