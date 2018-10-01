using System.Collections.Generic;

namespace Kanban.Shared.Domain
{
    public class Artifact
    {
        public Artifact(long id, string name, ArtifactType type, Project project, User assignedUser, ArtifactStatus status, Iteration iteration)
        {
            Id = id;
            Name = name;
            Type = type;
            Project = project;
            AssignedUser = assignedUser;
            Status = status;
            Iteration = iteration;
        }

        //For EF mapping
        protected Artifact()
        {}

        public long Id { get; private set; }
        public string Name { get; private set; }
        public ArtifactType Type { get; private set; }
        public Project Project { get; private set; }
        public User AssignedUser { get; private set; }
        public ArtifactStatus Status { get; private set; }
        public Iteration Iteration { get; private set; }
        public List<ArtifactAttachment> Attachments { get; private set; }
    }
}