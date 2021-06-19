using System;

namespace Domain
{
    public class Review
    {
        public string ConsultantId { get; set; }
        public AppUser Consultant { get; set; } 
        public string ClientId { get; set; }
        public AppUser Client { get; set; }
        public int StarRating { get; set; }
        public string Comment { get; set; }
    }
}