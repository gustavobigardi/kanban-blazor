namespace Kanban.Shared.Domain
{
    public class Project
    {
        public Project(long id, string name, bool active, User owner)
        {
            Id = id;
            Name = name;
            Active = active;
            Owner = owner;
        }

        //For EF mapping
        protected Project()
        {}

        public long Id { get; private set; }
        public string Name { get; private set; }
        public bool Active { get; private set; }
        public User Owner { get; private set; }
    }
}