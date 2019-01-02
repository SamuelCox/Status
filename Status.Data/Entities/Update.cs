using System;
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

        public string CreatedBy { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public string UserId { get; set; }

        public virtual IdentityUser Creator { get; set; }
    }
}
