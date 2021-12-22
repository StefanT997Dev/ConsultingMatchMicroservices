using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
	public class AdminUpdateMentorDto
	{
		[Required]
		public string Username { get; set; }
		public string PreviousRole { get; set; }
		public string NewRole { get; set; }
		public MentorPriceRateEnum PriceRate { get; set; }
	}
}
