using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
	public class CategoryWithSkillsDto
	{
		public ICollection<SkillDto> Skills { get; set; } = new List<SkillDto>();
	}
}
