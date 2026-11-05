using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Repositories
{
    public interface IBlogPostRepository
    {
            Task<List<BlogPost>> GetAllAsync();

            Task<BlogPost?> GetByIdAsync(int id);

            Task AddAsync(BlogPost blogPost);

            Task<bool> UpdateAsync(BlogPost blogPost);

            Task<bool> DeleteAsync(int id);
        }
    }
