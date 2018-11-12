using System.Collections.Generic;
using Kanban.Shared.Domain;

namespace Kanban.Server.Services
{
    public interface IProjectService
    {
        Project Create(Project project);
        Project Update(Project project);
        void Delete(long id);
        IEnumerable<Project> ListAll();
        IEnumerable<Project> ListAllActive();
        Project GetById(long id);
    }
}