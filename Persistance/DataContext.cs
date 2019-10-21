using System;
// using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistance
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions options):base(options)
        {

        }
        // public DbSet<Value> Values{get;set;}
        public DbSet<Domain.Value> Values { get; set; }
        
        public DbSet<Domain.Activity> Activities { get; set; }
        
    }
}
