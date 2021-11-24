using System;
using System.Collections.Generic;
using Application.DTOs;

namespace Application.Categories
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int NumberOfMentors { get; set; }
        public ICollection<MentorDisplayDto> Mentors { get; set; }
    }
}