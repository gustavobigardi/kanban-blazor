namespace Kanban.Shared.Domain
{
    public class User
    {
        public User(long id, string email, string password, string firstName, string lastName, bool active, Team team)
        {
            Id = id;
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Active = active;
            Team = team;
        }

        //For EF mapping
        protected User()
        {}

        public long Id { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public bool Active { get; private set; }
        public Team Team { get; private set; }
    }
}