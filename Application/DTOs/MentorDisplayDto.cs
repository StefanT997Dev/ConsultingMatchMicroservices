using System.Collections.Generic;
using Domain;

namespace Application.DTOs
{
    public class MentorDisplayDto
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string Image { get; set; }
        public string Bio { get; set; }
        public int NumberOfReviews { get; set; }
        public int TotalStarRating { get; set; }
        public int AverageStarReview { get; set; }
		public string Role { get; set; }
		public List<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
        public List<ReviewDto> Reviews { get; set; } = new List<ReviewDto>();
        public List<SkillDto> Skills { get; set; } = new List<SkillDto>();
	}
}