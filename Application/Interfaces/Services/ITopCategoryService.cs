using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Services
{
  public interface ITopCategoryService
    {
            Task<List<TopCategory>> GetAllAsync();

            Task<TopCategory?> GetByIdAsync(int id);

            Task<TopCategory> AddAsync(TopCategory category);

            Task<bool> UpdateAsync(TopCategory category);

            Task<bool> DeleteAsync(int id);
        }
    }

