using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;

namespace Application.Services
{
    public class BlogPostService : IBlogPostService
    {
        private readonly IBlogPostRepository _repository;

        public BlogPostService(IBlogPostRepository repository)
        {
            _repository = repository;
        }

        public Task<List<BlogPost>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<BlogPost?> GetByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public async Task<BlogPost> AddAsync(BlogPost blogPost)
        {
            await _repository.AddAsync(blogPost);
            return blogPost;
        }

        public Task<bool> UpdateAsync(BlogPost blogPost)
        {
            return _repository.UpdateAsync(blogPost);
        }

        public Task<bool> DeleteAsync(int id)
        {
            return _repository.DeleteAsync(id);
        }
    }
}