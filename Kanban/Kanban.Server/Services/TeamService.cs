using System.Collections.Generic;
using System.Linq;
using Kanban.Infra.Database.Repositories;
using Kanban.Shared.Domain;

namespace Kanban.Server.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _repository;

        public TeamService(ITeamRepository repository)
        {
            _repository = repository;
        }

        public Team Create(Team team)
        {
            _repository.Add(team);
            _repository.Save();
            return team;
        }

        public void Delete(long id)
        {
            var team = _repository.FindBy(u => u.Id == id).First();
            _repository.Delete(team);
            _repository.Save();
        }

        public Team FindById(long id)
        {
            return _repository.FindBy(t => t.Id == id).First();
        }

        public IEnumerable<Team> ListAll()
        {
            return _repository.GetAll();
        }

        public Team Update(Team team)
        {
            _repository.Edit(team);
            _repository.Save();
            return team;
        }
    }
}