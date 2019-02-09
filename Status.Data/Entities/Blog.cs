﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Status.Data.Entities
{
    public class Blog
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public string UserId { get; set; }

        public virtual IdentityUser AspNetUser { get; set; }
    }
}
