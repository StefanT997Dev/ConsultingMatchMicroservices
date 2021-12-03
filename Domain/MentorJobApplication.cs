using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
	public class MentorJobApplication
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public string Country { get; set; }
		public byte[] CV { get; set; }
		public byte[] MotivationalLetter { get; set; }
		public string Category { get; set; }
	}
}
