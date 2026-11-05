using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class BlogPost
    {
            public int Id { get; set; }

            public DateTime Date { get; set; }

            [Required]
            public string Category { get; set; } = string.Empty;

            [Required]
            public string Title { get; set; } = string.Empty;

            public string Description { get; set; } = string.Empty;

            public string ImagePath { get; set; } = string.Empty;

            public string Slug { get; set; } = string.Empty;
        }
    }

