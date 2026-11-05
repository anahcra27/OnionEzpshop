using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly AppDbContext _context;

        public BlogPostRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<BlogPost>> GetAllAsync()
        {
            return await _context.BlogPosts
                .AsNoTracking()
                .OrderByDescending(b => b.Date)
                .ToListAsync();
        }

        public async Task<BlogPost?> GetByIdAsync(int id)
        {
            return await _context.BlogPosts
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task AddAsync(BlogPost blogPost)
        {
            _context.BlogPosts.Add(blogPost);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(BlogPost blogPost)
        {
            var existing = await _context.BlogPosts
                .FindAsync(blogPost.Id);

            if (existing == null)
                return false;

            existing.Date = blogPost.Date;
            existing.Category = blogPost.Category;
            existing.Title = blogPost.Title;
            existing.Description = blogPost.Description;
            existing.ImagePath = blogPost.ImagePath;
            existing.Slug = blogPost.Slug;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var blogPost = await _context.BlogPosts.FindAsync(id);

            if (blogPost == null)
                return false;

            _context.BlogPosts.Remove(blogPost);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}