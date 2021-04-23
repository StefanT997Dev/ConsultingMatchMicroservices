using System;

namespace Domain
{
    public class AppUserLevel
    {
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public Guid LevelId { get; set; }
        public Level Level { get; set; }
        public int NumberOfCredits { get; set; }
    }
}