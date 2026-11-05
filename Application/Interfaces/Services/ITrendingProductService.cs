using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Services
{
    public interface ITrendingProductService
    {
    
        
            Task<List<TrendingProduct>> GetAllAsync();

            Task<TrendingProduct?> GetByIdAsync(int id);

            Task<TrendingProduct> AddAsync(TrendingProduct product);

            Task<bool> UpdateAsync(TrendingProduct product);

            Task<bool> DeleteAsync(int id);
        }
    }

