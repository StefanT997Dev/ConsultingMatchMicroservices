using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class FilterDto
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Molimo Vas unesite vrednost veću od {1}")]
        public int PageNumber { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Molimo Vas unesite vrednost veću od {1}")]
		public int PageSize { get; set; }
        public string Category { get; set; }
	}
}