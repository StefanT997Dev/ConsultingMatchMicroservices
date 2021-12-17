using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
	public class CategorySkill
	{
		public Guid CategoryId{ get; set; }
		public Category Category { get; set; }
		public Guid SkillId { get; set; }
		public Skill Skill { get; set; }
	}
}
