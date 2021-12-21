using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
	public class MentorshipDto
	{
		[Required]
		public string MentorId { get; set; }
		[Range(1,1000)]
		public int NumberOfSessions { get; set; }
	}
}
