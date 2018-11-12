using System.Collections.Generic;
using Kanban.Shared.Domain;

namespace Kanban.Server.Services
{
    public interface IArtifactService
    {
        Artifact Create(Artifact artifact);
        Artifact Update(Artifact artifact);
        void Delete(long id);
        IEnumerable<Artifact> ListAll();
        Artifact FindById(long id);
    }
}