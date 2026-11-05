using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Repositories
{
    public interface ITrendingProductRepository
    {
            Task<List<TrendingProduct>> GetAllAsync();

            Task<TrendingProduct?> GetByIdAsync(int id);

            Task AddAsync(TrendingProduct product);

            Task<bool> UpdateAsync(TrendingProduct product);

            Task<bool> DeleteAsync(int id);
        }
    }
