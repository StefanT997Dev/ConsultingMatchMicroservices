using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsService.Entities
{
	public class Review 
	{
		public int Id { get; set; }
		public int StarRating { get; set; }
		public string Comment { get; set; }
	}
}
