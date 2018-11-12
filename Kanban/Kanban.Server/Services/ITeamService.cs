using System.Collections.Generic;
using Kanban.Shared.Domain;

namespace Kanban.Server.Services
{
    public interface ITeamService
    {
        Team Create(Team team);
        Team Update(Team team);
        void Delete(long id);
        IEnumerable<Team> ListAll();
        Team FindById(long id);
    }
}