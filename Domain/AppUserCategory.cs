using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
	public class AppUserCategory
	{
		public string AppUserId { get; set; }
		public AppUser Mentor { get; set; }
		public Guid CategoryId { get; set; }
		public Category Category { get; set; }
	}
}
