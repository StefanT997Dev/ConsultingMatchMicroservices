using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class FilterDto
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int PageNumber { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int PageSize { get; set; }
    }
}