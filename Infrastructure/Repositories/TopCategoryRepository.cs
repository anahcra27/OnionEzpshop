using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TopCategoryRepository : ITopCategoryRepository
    {
        private readonly AppDbContext _context;

        public TopCategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TopCategory>> GetAllAsync()
        {
            return await _context.TopCategories
                .AsNoTracking()
                .OrderBy(c => c.Id)
                .ToListAsync();
        }

        public async Task<TopCategory?> GetByIdAsync(int id)
        {
            return await _context.TopCategories
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddAsync(TopCategory category)
        {
            _context.TopCategories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(TopCategory category)
        {
            var existing = await _context.TopCategories
                .FindAsync(category.Id);

            if (existing == null)
                return false;

            existing.CategoryName = category.CategoryName;
            existing.ImagePath = category.ImagePath;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _context.TopCategories.FindAsync(id);

            if (category == null)
                return false;

            _context.TopCategories.Remove(category);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}