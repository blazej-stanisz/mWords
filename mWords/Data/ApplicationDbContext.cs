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
        private int WordMaxLength = 1000;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<DictionaryEntry> WordsDictionary { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<DictionaryEntry>().ToTable("DictionaryEntries", schemaName);

            modelBuilder.Entity<DictionaryEntry>(entity => {
                entity.HasIndex(e => e.Word).IsUnique();
                entity.Property(e => e.Word).HasMaxLength(WordMaxLength).IsRequired();
                entity.Property(e => e.Word).HasMaxLength(WordMaxLength).IsRequired();
                entity.Property(e => e.Pronunciation).HasMaxLength(WordMaxLength);
            });
        }
    }
}
