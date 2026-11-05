using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AppDbContext _context;

        public AuthRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<AppUser?> GetByEmailAsync(string email)
        {
            return await _context.AppUsers
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<AppUser> AddAsync(AppUser user)
        {
            await _context.AppUsers.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }
    }
}