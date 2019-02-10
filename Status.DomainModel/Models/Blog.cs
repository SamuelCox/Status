using System;

namespace Status.DomainModel.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public User Creator { get; set; }
    }
}
