using System;
using System.Collections.Generic;

namespace Kanban.Shared.Domain
{
    public class Iteration
    {
        public Iteration(long id, string name, Team team, DateTime startDate, DateTime endDate)
        {
            Id = id;
            Name = name;
            Team = team;
            StartDate = startDate;
            EndDate = endDate;
        }

        //For EF mapping
        protected Iteration()
        {}

        public long Id { get; private set; }
        public string Name { get; private set; }
        public Team Team { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public List<Artifact> Artifacts {get; private set;}
    }
}