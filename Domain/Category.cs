using System;
using System.Collections.Generic;

namespace Domain
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<AppUserCategory> Mentors { get; set; } = new List<AppUserCategory>();
        public ICollection<CategorySkill> Skills { get; set; } = new List<CategorySkill>();
    }
}