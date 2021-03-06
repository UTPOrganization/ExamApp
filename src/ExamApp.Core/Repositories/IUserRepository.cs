using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExamApp.Core.Domain;

namespace ExamApp.Core.Repositories
{
    public interface IUserRepository : IRepository
    {
        Task<User> GetAsync(Guid id);
        Task<User> GetAsync(string email);
        Task<IEnumerable<User>> GetAllAsync(string name = "");
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(Guid id);
    }
}