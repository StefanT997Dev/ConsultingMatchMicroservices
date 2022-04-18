using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorsService.Entities
{
	public class Mentor
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Category { get; set; }
		public double Price { get; set; }
	}
}
