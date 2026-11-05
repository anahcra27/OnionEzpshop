using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto
{
    public class TopCategoryDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
    }
}
