using System;
using System.Collections.Generic;
using Application.Profiles;

namespace Application.Categories
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int NumberOfMentors { get; set; }
        public ICollection<Profile> Mentors { get; set; }
    }
}