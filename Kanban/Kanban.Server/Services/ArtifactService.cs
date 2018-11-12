using System.Collections.Generic;
using System.Linq;
using Kanban.Infra.Database.Repositories;
using Kanban.Shared.Domain;

namespace Kanban.Server.Services
{
    public class ArtifactService : IArtifactService
    {
        private readonly IArtifactRepository _repository;
        private readonly IArtifactStatusRepository _statusRepository;
        private readonly IArtifactTypeRepository _typeRepository;
        private readonly IArtifactAttachmentRepository _attachmentRepository;

        public ArtifactService(IArtifactRepository repository,
                               IArtifactStatusRepository statusRepository,
                               IArtifactTypeRepository typeRepository,
                               IArtifactAttachmentRepository attachmentRepository)
        {
            _repository = repository;
            _statusRepository = statusRepository;
            _typeRepository = typeRepository;
            _attachmentRepository = attachmentRepository;
        }
        public Artifact Create(Artifact artifact)
        {
            _repository.Add(artifact);
            _repository.Save();
            return artifact;
        }

        public void Delete(long id)
        {
            var artifact = _repository.FindBy(u => u.Id == id).First();
            _repository.Delete(artifact);
            _repository.Save();
        }

        public Artifact FindById(long id)
        {
            return _repository.FindBy(a => a.Id == id).First();
        }

        public IEnumerable<Artifact> ListAll()
        {
            return _repository.GetAll().ToList();
        }

        public Artifact Update(Artifact artifact)
        {
            _repository.Edit(artifact);
            _repository.Save();
            return artifact;
        }
    }
}