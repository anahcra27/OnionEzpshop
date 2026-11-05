using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class TrendingProductRepository : ITrendingProductRepository
        {
            private readonly AppDbContext _context;

            public TrendingProductRepository(AppDbContext context)
            {
                _context = context;
            }

            public async Task<List<TrendingProduct>> GetAllAsync()
            {
                return await _context.TrendingProducts
                    .AsNoTracking()
                    .OrderBy(p => p.Id)
                    .ToListAsync();
            }

            public async Task<TrendingProduct?> GetByIdAsync(int id)
            {
                return await _context.TrendingProducts
                    .AsNoTracking()
                    .FirstOrDefaultAsync(p => p.Id == id);
            }

            public async Task AddAsync(TrendingProduct product)
            {
                _context.TrendingProducts.Add(product);
                await _context.SaveChangesAsync();
            }

            public async Task<bool> UpdateAsync(TrendingProduct product)
            {
                var existing = await _context.TrendingProducts
                    .FindAsync(product.Id);

                if (existing == null)
                    return false;

                existing.Name = product.Name;
                existing.Category = product.Category;
                existing.Price = product.Price;
                existing.OriginalPrice = product.OriginalPrice;
                existing.Discount = product.Discount;
                existing.Rating = product.Rating;
                existing.Reviews = product.Reviews;
                existing.ImagePath = product.ImagePath;
                existing.Badge = product.Badge;

                await _context.SaveChangesAsync();
                return true;
            }

            public async Task<bool> DeleteAsync(int id)
            {
                var product = await _context.TrendingProducts
                    .FindAsync(id);

                if (product == null)
                    return false;

                _context.TrendingProducts.Remove(product);
                await _context.SaveChangesAsync();

                return true;
            }
        }
    }

