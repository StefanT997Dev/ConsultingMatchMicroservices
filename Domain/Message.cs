using System;

namespace Domain
{
    public class Message
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public AppUser Consultant { get; set; }
    }
}