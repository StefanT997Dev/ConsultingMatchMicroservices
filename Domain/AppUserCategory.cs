using System;

namespace Domain
{
    public class AppUserCategory
    {
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}