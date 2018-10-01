using System.Collections.Generic;

namespace Kanban.Shared.Domain
{
    public class ArtifactType
    {
        public ArtifactType(long id, string name, bool active)
        {
            Id = id;
            Name = name;
            Active = active;
        }

        //For EF mapping
        protected ArtifactType()
        {}

        public long Id { get; private set; }
        public string Name { get; private set; }
        public bool Active { get; private set; }
        public List<ArtifactStatus> Statuses { get; private set; }
    }
}