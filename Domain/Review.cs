using System;

namespace Domain
{
    public class Review
    {
        public Guid Id { get; set; }
        public int StarRating { get; set; }
        public string Comment { get; set; }
        public AppUser Consultant { get; set; }
    }
}