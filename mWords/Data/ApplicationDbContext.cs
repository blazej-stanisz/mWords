using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using mWords.Models.EntityModels;

namespace mWords.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser<long>, IdentityRole<long>, long>
    {
        private string schemaName = "mw";
        private int WordMaxLength = 1000;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<DictionaryEntry> DictionaryEntries { get; set; }

        public DbSet<DictionarySet> DictionarySets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // DictionaryEntry
            modelBuilder.Entity<DictionaryEntry>().ToTable("DictionaryEntries", schemaName);

            modelBuilder.Entity<DictionaryEntry>(entity => {
                entity.HasIndex(e => e.Word).IsUnique();
                entity.Property(e => e.Word).HasMaxLength(WordMaxLength).IsRequired();
                entity.Property(e => e.Word).HasMaxLength(WordMaxLength).IsRequired();
                entity.Property(e => e.Pronunciation).HasMaxLength(WordMaxLength);
            });

            modelBuilder.Entity<DictionaryEntry>()
                .HasOne<DictionarySet>(s => s.DictionarySet)
                .WithMany(c => c.DictionaryEntries);

            // DictionarySet
            modelBuilder.Entity<DictionarySet>().ToTable("DictionarySets", schemaName);

            modelBuilder.Entity<DictionarySet>(entity => {
                entity.HasIndex(e => e.Name).IsUnique();
                entity.Property(e => e.Name).HasMaxLength(WordMaxLength).IsRequired();
                entity.Property(e => e.Description).HasMaxLength(WordMaxLength).IsRequired();
                entity.Property(e => e.Level).HasMaxLength(WordMaxLength).IsRequired();
                entity.Property(e => e.CoverColorHex).HasMaxLength(WordMaxLength).IsRequired();
            });
        }
    }
}
