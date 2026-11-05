using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto
{
    public class BlogPostDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
    }
}
