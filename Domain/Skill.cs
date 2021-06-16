using System;
using System.Collections.Generic;

namespace Domain
{
    public class Skill
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<CategorySkill> Categories { get; set; }=new List<CategorySkill>();
    }
}