using System;
using System.Collections.Generic;
using System.Text;

namespace Status.Data.Entities
{
    public class Blog
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public string CreatedBy { get; set; }
    }
}
