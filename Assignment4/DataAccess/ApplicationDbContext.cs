using ISM6225_Assignment4.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISM6225_Assignment4.DataAccess
{
    public class ApplicationDbContext : DbContext
    {

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Attributes>()
        //      .Property(a => a.AuthorId)
        //      .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        //    base.OnModelCreating(modelBuilder);
        //}
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Attributes> FishingAreas { get; set; }
    }
}
