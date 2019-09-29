using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using mWords.Models;

namespace mWords.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        private string schemaName = "mw";

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<WordsDictionary> WordsDictionary { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<WordsDictionary>().ToTable("WordsDictionary", schemaName);
        }
    }
}
