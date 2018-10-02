using Kanban.Infra.Database.Contexts;
using Kanban.Shared.Domain;

namespace Kanban.Infra.Database.Repositories
{
    public class ArtifactRepository : GenericRepository<Artifact>, IArtifactRepository
    {
        public ArtifactRepository(KanbanContext context) : base(context)
        {
        }
    }
}