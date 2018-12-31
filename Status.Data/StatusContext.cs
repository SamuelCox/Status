using System;
using Microsoft.EntityFrameworkCore;
using Status.Data.Entities;

namespace Status.Data
{
    public class StatusContext : DbContext, IStatusContext
    {

        public virtual DbSet<Update> Updates { get; set; }

        public virtual DbSet<Blog> Blogs { get; set; }

        public StatusContext(DbContextOptions<StatusContext> options) : base(options)
        {           
        }



        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer();
        //}
    }
}
