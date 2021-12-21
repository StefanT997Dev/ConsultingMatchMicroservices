using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
	public class Mentorship
	{
		public string MentorId { get; set; }
		public AppUser Mentor { get; set; }
		public string ClientId { get; set; }
		public AppUser Client { get; set; }
		public int? NumberOfSessions { get; set; }
	}
}
