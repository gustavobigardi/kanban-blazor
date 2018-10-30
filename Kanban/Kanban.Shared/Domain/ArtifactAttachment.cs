namespace Kanban.Shared.Domain
{
    public class ArtifactAttachment
    {
        public ArtifactAttachment(long id, string name, byte[] content, Artifact artifact)
        {
            Id = id;
            Name = name;
            Content = content;
            Artifact = artifact;
        }

        //For EF mapping
        public ArtifactAttachment()
        {}

        public long Id { get; private set; }
        public string Name { get; private set; }
        public byte[] Content { get; private set; }
        public Artifact Artifact { get; private set; }
    }
}