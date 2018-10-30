namespace Kanban.Shared.Domain
{
    public class ArtifactStatus
    {
        public ArtifactStatus(long id, string name, bool active, ArtifactType type)
        {
            Id = id;
            Name = name;
            Active = active;
            Type = type;
        }

        //For EF mapping
        protected ArtifactStatus()
        {}

        public long Id { get; private set; }
        public string Name { get; private set; }
        public bool Active { get; private set; }
        public ArtifactType Type { get; private set; }
    }
}