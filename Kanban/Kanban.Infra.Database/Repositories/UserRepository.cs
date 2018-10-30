using Kanban.Infra.Database.Contexts;
using Kanban.Shared.Domain;

namespace Kanban.Infra.Database.Repositories
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(KanbanContext context) : base(context)
        {
        }
    }
}