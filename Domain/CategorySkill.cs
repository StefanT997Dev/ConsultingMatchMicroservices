using System;

namespace Domain
{
    public class CategorySkill
    {
        public Guid SkillId { get; set; }
        public Skill Skill { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}