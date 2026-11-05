using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Repositories
{
    public interface IAuthRepository
    {
        Task<AppUser?> GetByEmailAsync(string email);

        Task<AppUser> AddAsync(AppUser user);
    }
}
