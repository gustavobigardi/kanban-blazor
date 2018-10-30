using Kanban.Infra.Database.Contexts;
using Kanban.Shared.Domain;

namespace Kanban.Infra.Database.Repositories
{
    public class ArtifactAttachmentRepository : GenericRepository<ArtifactAttachment>, IArtifactAttachmentRepository
    {
        public ArtifactAttachmentRepository(KanbanContext context) : base(context)
        {
        }
    }
}