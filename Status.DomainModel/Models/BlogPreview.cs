using System;

namespace Status.DomainModel.Models
{
    public class BlogPreview
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PreviewText { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public User Creator { get; set; }
    }
}
