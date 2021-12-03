using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
	public class MentorDto
	{
		[Required(ErrorMessage = "Morate proslediti id mentora")]
		public string Id { get; set; }
	}
}
