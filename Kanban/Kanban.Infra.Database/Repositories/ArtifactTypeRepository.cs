using Kanban.Infra.Database.Contexts;
using Kanban.Shared.Domain;

namespace Kanban.Infra.Database.Repositories
{
    public class ArtifactTypeRepository : GenericRepository<ArtifactType>, IArtifactTypeRepository
    {
        public ArtifactTypeRepository(KanbanContext context) : base(context)
        {
        }
    }
}