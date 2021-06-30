using System;

namespace Domain
{
    public class AppUserSkill
    {
        public string ConsultantId { get; set; }
        public AppUser Consultant { get; set; }
        public Guid SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}