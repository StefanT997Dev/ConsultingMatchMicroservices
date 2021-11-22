using System;

namespace Domain
{
    public class Message
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public AppUser Mentor { get; set; }
    }
}