using System;
using System.Collections.Generic;
using System.Text;

namespace Status.DomainModel.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public User Creator { get; set; }
    }
}
