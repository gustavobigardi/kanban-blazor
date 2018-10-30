using Kanban.Infra.Database.Contexts;
using Kanban.Shared.Domain;

namespace Kanban.Infra.Database.Repositories
{
    public class IterationRepository : GenericRepository<Iteration>, IIterationRepository
    {
        public IterationRepository(KanbanContext context) : base(context)
        {
        }
    }
}