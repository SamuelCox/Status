using System;
using System.Collections.Generic;
using System.Text;

namespace Status.DomainModel.Models
{
    public class Update
    {
        public string Text { get; set; }        
        public DateTimeOffset CreatedDate { get; set; }
        public User User { get; set; }
    }
}
