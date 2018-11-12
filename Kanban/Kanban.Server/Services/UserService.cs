using System;
using System.Collections.Generic;
using System.Linq;
using Kanban.Infra.Database.Contexts;
using Kanban.Infra.Database.Repositories;
using Kanban.Shared.Domain;
using Microsoft.EntityFrameworkCore;

namespace Kanban.Server.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public User Create(User user)
        {
           _repository.Add(user);
           _repository.Save();
            return user;
        }

        public void Delete(long id)
        {
            var user = _repository.FindBy(u => u.Id == id).First();
            _repository.Delete(user);
            _repository.Save();
        }

        public User FindByEmail(string email)
        {
            return _repository.FindByEmail(email);
        }

        public User FindById(long id)
        {
            return _repository.FindBy(u => u.Id == id).First();
        }

        public IEnumerable<User> ListAll()
        {
            return _repository.GetAll().ToList();
        }

        public User Update(User user)
        {
            _repository.Edit(user);
            _repository.Save();
            return user;
        }
    }
}