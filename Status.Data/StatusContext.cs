using System;
using Microsoft.EntityFrameworkCore;

namespace Status.Data
{
    public class StatusContext : DbContext
    {

        public StatusContext(DbContextOptions<StatusContext> options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer();
        //}
    }
}
