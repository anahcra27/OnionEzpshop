using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class TopCategory
    {
            public int Id { get; set; }

            [Required]
            public string CategoryName { get; set; } = string.Empty;

            public string ImagePath { get; set; } = string.Empty;
        }
    }

