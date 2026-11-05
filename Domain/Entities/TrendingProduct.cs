using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class TrendingProduct
    {
            public int Id { get; set; }

            [Required]
            public string Name { get; set; } = string.Empty;

            public string Category { get; set; } = string.Empty;

            public decimal Price { get; set; }

            public decimal OriginalPrice { get; set; }

            public int? Discount { get; set; }

            public decimal Rating { get; set; }

            public int Reviews { get; set; }

            public string ImagePath { get; set; } = string.Empty;

            public string? Badge { get; set; }
        }
    }
