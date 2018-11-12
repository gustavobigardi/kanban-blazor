using System.Collections.Generic;
using System.Linq;
using Kanban.Infra.Database.Repositories;
using Kanban.Shared.Domain;

namespace Kanban.Server.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _repository;

        public ProjectService(IProjectRepository repository)
        {
            _repository = repository;
        }

        public Project Create(Project project)
        {
            _repository.Add(project);
            _repository.Save();
            return project;
        }

        public void Delete(long id)
        {
            var project = _repository.FindBy(p => p.Id == id).First();
            _repository.Delete(project);
            _repository.Save();
        }

        public Project GetById(long id)
        {
            return _repository.FindBy(p => p.Id == id).First();
        }

        public IEnumerable<Project> ListAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<Project> ListAllActive()
        {
            return _repository.FindBy(p => p.Active).ToList();
        }

        public Project Update(Project project)
        {
            _repository.Edit(project);
            _repository.Save();
            return project;
        }
    }
}