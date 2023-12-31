using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PointCounting.MyDatabase
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("Sindesmos")
        {
            
        }

        //public DbSet<Student> Students { get; set; }
    }
}