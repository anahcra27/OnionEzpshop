using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class TopCategoryService: ITopCategoryService
        {
            private readonly ITopCategoryRepository _repository;

            public TopCategoryService(ITopCategoryRepository repository)
            {
                _repository = repository;
            }

            public Task<List<TopCategory>> GetAllAsync()
            {
                return _repository.GetAllAsync();
            }

            public Task<TopCategory?> GetByIdAsync(int id)
            {
                return _repository.GetByIdAsync(id);
            }

            public async Task<TopCategory> AddAsync(TopCategory category)
            {
                await _repository.AddAsync(category);
                return category;
            }

            public Task<bool> UpdateAsync(TopCategory category)
            {
                return _repository.UpdateAsync(category);
            }

            public Task<bool> DeleteAsync(int id)
            {
                return _repository.DeleteAsync(id);
            }
        }
    }


