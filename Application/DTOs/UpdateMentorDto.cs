using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
	public class UpdateMentorDto
	{
		[Required]
		public string Id { get; set; }
		public string DisplayName { get; set; }
		public string Bio { get; set; }
		public List<SkillDto> Skills { get; set; }
	}
}
