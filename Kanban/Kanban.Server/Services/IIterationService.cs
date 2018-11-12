using System.Collections.Generic;
using Kanban.Shared.Domain;

namespace Kanban.Server.Services
{
    public interface IIterationService
    {
        Iteration Create(Iteration iteration);
        Iteration Update(Iteration iteration);
        void Delete(long id);
        IEnumerable<Iteration> ListAll();
        Iteration FindById(long id);
    }
}