using System.Collections.Generic;
using System.Linq;
using Kanban.Infra.Database.Repositories;
using Kanban.Shared.Domain;

namespace Kanban.Server.Services
{
    public class IterationService : IIterationService
    {
        private readonly IIterationRepository _repository;

        public IterationService(IIterationRepository repository)
        {
            _repository = repository;
        }

        public Iteration Create(Iteration iteration)
        {
            _repository.Add(iteration);
            _repository.Save();
            return iteration;
        }

        public void Delete(long id)
        {
            var iteration = _repository.FindBy(u => u.Id == id).First();
            _repository.Delete(iteration);
            _repository.Save();
        }

        public Iteration FindById(long id)
        {
            return _repository.FindBy(u => u.Id == id).First();
        }

        public IEnumerable<Iteration> ListAll()
        {
            return _repository.GetAll().ToList();
        }

        public Iteration Update(Iteration iteration)
        {
            _repository.Edit(iteration);
            _repository.Save();
            return iteration;
        }
    }
}