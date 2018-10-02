using Kanban.Infra.Database.Contexts;
using Kanban.Shared.Domain;

namespace Kanban.Infra.Database.Repositories
{
    public class ArtifactStatusRepository : GenericRepository<ArtifactStatus>, IArtifactStatusRepository
    {
        public ArtifactStatusRepository(KanbanContext context) : base(context)
        {
        }
    }
}