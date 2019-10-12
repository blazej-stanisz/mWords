using ExcelDataReader;
using mWords.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace mWords.Data
{
    public static class ApplicationDbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.DictionaryEntries.Any())
            {
                return; // DB has been seeded
            }

            AddDictionarySets(context);
            ImportDictionaryEntries(context);
            InsertTestUserData(context);
            InsertEntryAssignments(context);
        }

        private static void AddDictionarySets(ApplicationDbContext context)
        {
            context.DictionarySets.Add(new DictionarySet
            {
                Name = "1001 English Words",
                Description = "The Elementary/Intermediate set of 1001 English words.",
                LanguagesPair = "EN-PL",
                Level = "A1-B1",
                LevelDescription = "Elementary/Intermediate Level",
                CoverColorHex = "#E8F8F5" // https://htmlcolorcodes.com/
            });

            context.DictionarySets.Add(new DictionarySet
            {
                Name = "1000 English Words",
                Description = "The Intermediate/Upper-Intermediate set of 1000 English words.",
                LanguagesPair = "EN-PL",
                Level = "B1-B2",
                LevelDescription = "Intermediate/Upper-Intermediate",
                CoverColorHex = "#FEF9E7"
            });

            context.SaveChanges();
        }

        private static void ImportDictionaryEntries(ApplicationDbContext context)
        {
            var wordsListPath = $"{Directory.GetCurrentDirectory()}\\Data\\WordsList.xlsx";

            if (!File.Exists(wordsListPath))
            {
                throw new FileNotFoundException("Cannot find file WordsList.xlsx");
            }

            try
            {
                var set1 = context.DictionarySets.FirstOrDefault(x => x.Id == 1); // TODO: change this

                using (var stream = File.Open(wordsListPath, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        do
                        {
                            while (reader.Read())
                            {
                                var word = reader.GetString(0);
                                var translation = reader.GetString(1);
                                var pronunciation = reader.GetString(2);

                                context.DictionaryEntries.Add(new DictionaryEntry { Word = word, Translation = translation, Pronunciation = pronunciation, DictionarySet = set1 });
                            }
                        } while (reader.NextResult()); // next Sheet
                    }
                }
            }
            catch (Exception e)
            {
                new Exception($"Error while reading WordsList file. Exception {e.Message}");
            }

            context.SaveChanges();
        }

        private static void InsertTestUserData(ApplicationDbContext context)
        {
            context.Users.Add(new ApplicationUser<long>
            {
                UserName = "testuser@test.com",
                NormalizedUserName = "TESTUSER@TEST.COM",
                Email = "testuser@test.com",
                NormalizedEmail = "TESTUSER@TEST.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAECPxvo2QMVeWsICbL5VP5go18aisGZTgtrifrtDCUqjEdmZrUkmRphudPaVhEoY6NQ==",
                SecurityStamp = "2KJB4VZPEAJYBAKN5WFX4OFGSAQCWDUG",
                ConcurrencyStamp = "9d4ea234-02ee-440d-a9a0-4f23301f5fd4",
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = true,
                AccessFailedCount = 0
            });

            context.SaveChanges();
        }

        private static void InsertEntryAssignments(ApplicationDbContext context)
        {
            var user1 = context.Users.FirstOrDefault(x => x.Id == 1); // TODO: change this
            var dictionaryEntry1 = context.DictionaryEntries.FirstOrDefault(x => x.Id == 1); // TODO: change this
            var dictionaryEntry2 = context.DictionaryEntries.FirstOrDefault(x => x.Id == 2); // TODO: change this
            var dictionaryEntry3 = context.DictionaryEntries.FirstOrDefault(x => x.Id == 3); // TODO: change this
            var dictionaryEntry4 = context.DictionaryEntries.FirstOrDefault(x => x.Id == 4); // TODO: change this

            context.EntryAssignments.Add(new EntryAssignment { ApplicationUser = user1, DictionaryEntry = dictionaryEntry1 });
            context.EntryAssignments.Add(new EntryAssignment { ApplicationUser = user1, DictionaryEntry = dictionaryEntry2 });
            context.EntryAssignments.Add(new EntryAssignment { ApplicationUser = user1, DictionaryEntry = dictionaryEntry3 });
            context.EntryAssignments.Add(new EntryAssignment { ApplicationUser = user1, DictionaryEntry = dictionaryEntry4 });

            context.SaveChanges();
        }
    }
}
