using System;

namespace Domain
{
    public class AppUserSkill
    {
        public string MentorId { get; set; }
        public AppUser Mentor { get; set; }
        public Guid SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}