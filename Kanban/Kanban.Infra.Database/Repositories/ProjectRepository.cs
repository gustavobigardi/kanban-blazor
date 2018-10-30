using Kanban.Infra.Database.Contexts;
using Kanban.Shared.Domain;

namespace Kanban.Infra.Database.Repositories
{
    public class ProjectRepository : GenericRepository<Project>
    {
        public ProjectRepository(KanbanContext context) : base(context)
        {
        }
    }
}