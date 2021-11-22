using System.Collections.Generic;
using Newtonsoft.Json;

namespace Application.DTOs
{
    public class MentorsearchDto
    {
        public string DisplayName { get; set; }
        public ICollection<SkillDto> Skills { get; set; }
    }
}