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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>().HasKey(x => x.Id);
            modelBuilder.Entity<Update>().HasKey(x => x.Id);            
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer();
        //}
    }
}
