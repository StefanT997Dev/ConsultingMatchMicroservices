using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
	public class Package
	{
		public int Id { get; set; }
		public int NumberOfSessions { get; set; }
		public int DurationInMonths { get; set; }
		public string MentorId { get; set; }
		public AppUser Mentor { get; set; }
	}
}
