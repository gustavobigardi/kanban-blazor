using System;
using System.Linq;
using Kanban.Infra.Database.Contexts;
using Kanban.Shared.Domain;

namespace Kanban.Infra.Database.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(KanbanContext context) : base(context)
        {
        }

        public User FindByEmail(string email)
        {
            return Context.Users.First(u => u.Email.Equals(email, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}