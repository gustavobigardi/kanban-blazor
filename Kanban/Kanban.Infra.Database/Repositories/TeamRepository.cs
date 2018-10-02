using Kanban.Infra.Database.Contexts;
using Kanban.Shared.Domain;

namespace Kanban.Infra.Database.Repositories
{
    public class TeamRepository : GenericRepository<Team>
    {
        public TeamRepository(KanbanContext context) : base(context)
        {
        }
    }
}