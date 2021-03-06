﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Status.Data.Entities
{
    public class Update
    {
        public int Id { get; set; }

        [MaxLength(500)]
        public string Text { get; set; }        

        public DateTimeOffset CreatedDate { get; set; }

        public string UserId { get; set; }

        public virtual IdentityUser AspNetUser { get; set; }
    }
}
