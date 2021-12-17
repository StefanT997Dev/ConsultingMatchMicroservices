using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class AppUser:IdentityUser
    {
		public string DisplayName { get; set; }
        public string Bio { get; set; }
        public string SalesVideo { get; set; }
        public string ProfilePicture { get; set; }
        public Photo Photo { get; set; }
		public Role Role { get; set; }
		public ICollection<AppUserCategory> Categories { get; set; }
        public ICollection<AppUserSkill> Skills { get; set; }
        public ICollection<Review> MentorReviews { get; set; }
        public ICollection<Review> ClientReviews { get; set; }
    }
}