using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Repositories
{
   public interface ITopCategoryRepository
    {
            Task<List<TopCategory>> GetAllAsync();

            Task<TopCategory?> GetByIdAsync(int id);

            Task AddAsync(TopCategory category);

            Task<bool> UpdateAsync(TopCategory category);

            Task<bool> DeleteAsync(int id);
        }
    }
