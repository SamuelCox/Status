using System;
using System.Collections.Generic;
using System.Text;

namespace Status.DomainModel.Models
{
    public class Update
    {
        public string Text { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
