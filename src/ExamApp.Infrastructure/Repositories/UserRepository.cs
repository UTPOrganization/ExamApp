using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamApp.Core.Domain;
using ExamApp.Core.Repositories;

namespace ExamApp.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static readonly ISet<User> _users = new HashSet<User>();
        public async Task<User> GetAsync(Guid id)
            => await Task.FromResult(_users.SingleOrDefault(x => x.Id == id));

        public async Task<User> GetAsync(string email)
            => await Task.FromResult(_users.SingleOrDefault(x => 
                x.Email.ToLowerInvariant() == email.ToLowerInvariant()));

        public async Task<IEnumerable<User>> GetAllAsync(string name = "")
        {
            var users = _users.AsEnumerable();
            if(!string.IsNullOrWhiteSpace(name))
            {
                users = users.Where(x => x.Name.ToLowerInvariant()
                    .Contains(name.ToLowerInvariant()));
            }

            return await Task.FromResult(users);
        }

        public async Task AddAsync(User user)
        {
            _users.Add(user);
            await Task.CompletedTask;
        } 

        public async Task UpdateAsync(User user)
        {
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await GetAsync(id);
            _users.Remove(user);
            await Task.CompletedTask;
        }
    }
}