using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExamApp.Infrastructure.DTO;

namespace ExamApp.Infrastructure.Services
{
    public interface IUserService : IService
    {
        Task<AccountDto> GetAccountAsync(Guid userId);
        Task<IEnumerable<AccountDto>> BrowseAsync();
        Task RegisterAsync(Guid userId, string email, string name, string password, string role);
        
        Task<TokenDto> LoginAsync(string email, string password);
    }
}