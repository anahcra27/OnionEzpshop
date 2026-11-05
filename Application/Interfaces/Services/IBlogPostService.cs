using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface IBlogPostService
    {
        Task<List<BlogPost>> GetAllAsync();

        Task<BlogPost?> GetByIdAsync(int id);

        Task<BlogPost> AddAsync(BlogPost blogPost);

        Task<bool> UpdateAsync(BlogPost blogPost);

        Task<bool> DeleteAsync(int id);
    }
}