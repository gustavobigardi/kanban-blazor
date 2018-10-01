using System.Collections.Generic;

namespace Kanban.Shared.Domain
{
    public class Team
    {
        public Team(long id, string name, bool active)
        {
            Id = id;
            Name = name;
            Active = active;
        }

        //For EF mapping
        protected Team()
        { }

        public long Id { get; private set; }
        public string Name { get; private set; }
        public bool Active { get; private set; }
        public List<Iteration> Iterations { get; private set; }
        public List<User> Members { get; private set; }
    }
}