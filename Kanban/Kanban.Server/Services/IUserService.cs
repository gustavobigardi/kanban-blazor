using System.Collections.Generic;
using Kanban.Shared.Domain;

namespace Kanban.Server.Services
{
    public interface IUserService
    {
         User Create(User user);
         User Update(User user);
         void Delete(long id);
         IEnumerable<User> ListAll();
         User FindByEmail(string email);
         User FindById(long id);
    }
}