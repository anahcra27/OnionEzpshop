using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class TrendingProductService: ITrendingProductService
        {
            private readonly ITrendingProductRepository _repository;

            public TrendingProductService(
                ITrendingProductRepository repository)
            {
                _repository = repository;
            }

            public Task<List<TrendingProduct>> GetAllAsync()
            {
                return _repository.GetAllAsync();
            }

            public Task<TrendingProduct?> GetByIdAsync(int id)
            {
                return _repository.GetByIdAsync(id);
            }

            public async Task<TrendingProduct> AddAsync(
                TrendingProduct product)
            {
                await _repository.AddAsync(product);
                return product;
            }

            public Task<bool> UpdateAsync(TrendingProduct product)
            {
                return _repository.UpdateAsync(product);
            }

            public Task<bool> DeleteAsync(int id)
            {
                return _repository.DeleteAsync(id);
            }
        }
    }


