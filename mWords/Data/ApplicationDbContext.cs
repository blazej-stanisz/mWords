using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using mWords.Models.EntityModels;

namespace mWords.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser<long>, IdentityRole<long>, long>
    {
        private string schemaName = "mw";
        private int WordMaxLength = 1000;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<DictionaryEntry> DictionaryEntries { get; set; }

        public DbSet<DictionarySet> DictionarySets { get; set; }

        public DbSet<EntryAssignment> EntryAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // DictionaryEntry
            modelBuilder.Entity<DictionaryEntry>(b =>
            {
                // Primary key
                b.HasKey(u => u.Id);

                // Indexes for "normalized" Word and Translation, to allow efficient lookups
                b.HasIndex(u => u.Word).IsUnique();
                b.HasIndex(u => u.Translation);

                // Maps to the DictionaryEntries table
                b.ToTable("DictionaryEntries", schemaName);

                // Limit the size of columns to use efficient database types
                b.Property(u => u.Word).HasMaxLength(WordMaxLength).IsRequired();
                b.Property(u => u.Translation).HasMaxLength(WordMaxLength).IsRequired();
                b.Property(e => e.Pronunciation).HasMaxLength(WordMaxLength);

                // The relationships between DictionaryEntry and other entity types

                // Each DictionaryEntry can have one DictionarySet
                b.HasOne(de => de.DictionarySet).WithMany(ds => ds.DictionaryEntries).IsRequired();

                // Each DictionaryEntry can have many EntryAssignments
                b.HasMany(de => de.EntryAssignments).WithOne(ea => ea.DictionaryEntry).HasForeignKey(ea => ea.DictionaryEntryId).IsRequired();
            });

            // DictionarySet
            modelBuilder.Entity<DictionarySet>(b =>
            {
                // Primary key
                b.HasKey(u => u.Id);

                // Indexes for "normalized" Name, to allow efficient lookups
                b.HasIndex(u => u.Name);

                // Maps to the DictionarySets table
                b.ToTable("DictionarySets", schemaName);

                // Limit the size of columns to use efficient database types
                b.Property(e => e.Name).HasMaxLength(WordMaxLength).IsRequired();
                b.Property(e => e.Description).HasMaxLength(WordMaxLength).IsRequired();
                b.Property(e => e.LanguagesPair).HasMaxLength(WordMaxLength).IsRequired();
                b.Property(e => e.Level).HasMaxLength(WordMaxLength).IsRequired();
                b.Property(e => e.LevelDescription).HasMaxLength(WordMaxLength).IsRequired();
                b.Property(e => e.CoverColorHex).HasMaxLength(WordMaxLength).IsRequired();

                // The relationships between DictionarySet and other entity types

                // Each DictionarySet can have many DictionaryEntries
                b.HasMany(ds => ds.DictionaryEntries).WithOne(de => de.DictionarySet).HasForeignKey(ea => ea.DictionarySetId).IsRequired();
            });

            // EntryAssignment
            modelBuilder.Entity<EntryAssignment>(b =>
            {
                // Primary key
                b.HasKey(u => u.Id);

                // Maps to the DictionaryEntries table
                b.ToTable("EntryAssignments", schemaName);

                // The relationships between EntryAssignment and other entity types

                // Each EntryAssignment can have one DictionaryEntry
                b.HasOne(ea => ea.DictionaryEntry).WithMany(de => de.EntryAssignments).IsRequired();

                // Each EntryAssignment can have one ApplicationUser
                b.HasOne(ea => ea.ApplicationUser).WithMany(de => de.EntryAssignments).IsRequired();

                // Pigeonhole default value
                b.Property(b => b.Pigeonhole).HasDefaultValueSql("1");

                // AttemptDate default value
                b.Property(b => b.AttemptDate).HasDefaultValueSql("getdate()");
            });

            // ApplicationUser
            modelBuilder.Entity<ApplicationUser<long>>(b =>
            {
                // The relationships between ApplicationUser and other entity types

                // Each ApplicationUser can have many EntryAssignments
                b.HasMany(ds => ds.EntryAssignments).WithOne(de => de.ApplicationUser).HasForeignKey(ea => ea.ApplicationUserId).IsRequired();
            });
        }
    }
}
