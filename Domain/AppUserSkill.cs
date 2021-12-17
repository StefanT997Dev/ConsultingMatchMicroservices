using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
	public class AppUserSkill
	{
		public string MentorId { get; set; }
		public AppUser Mentor { get; set; }
		public Guid SkillId { get; set; }
		public Skill Skill { get; set; }
	}
}
