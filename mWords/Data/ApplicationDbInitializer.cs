using ExcelDataReader;
using mWords.Models;
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
            var wordsListPath = $"{Directory.GetCurrentDirectory()}\\Data\\WordsList.xlsx";

            context.Database.EnsureCreated();

            if (context.WordsDictionary.Any())
            {
                return; // DB has been seeded
            }

            if (!File.Exists(wordsListPath))
            {
                throw new FileNotFoundException("Cannot find file WordsList.xlsx");
            }

            try
            {
                using (var stream = File.Open(wordsListPath, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        do
                        {
                            while (reader.Read())
                            {
                                var englishWord = reader.GetString(0);
                                var polishWord = reader.GetString(1);
                                var pronunciation = reader.GetString(2);

                                context.WordsDictionary.Add(new WordsDictionary { English = englishWord, Polish = polishWord, Pronunciation = pronunciation });
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
    }
}
