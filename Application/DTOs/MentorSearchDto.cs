using System.Collections.Generic;
using Domain;
using Newtonsoft.Json;

namespace Application.DTOs
{
    public class MentorSearchDto
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public ICollection<SkillDto> Skills { get; set; }
	}
}