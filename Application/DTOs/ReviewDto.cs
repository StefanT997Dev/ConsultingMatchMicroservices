using System;

namespace Application.DTOs
{
    public class ReviewDto
    {
        public Guid Id { get; set; }
        public int StarRating { get; set; }
        public string Comment { get; set; }
    }
}