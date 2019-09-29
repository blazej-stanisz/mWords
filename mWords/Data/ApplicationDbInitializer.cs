using mWords.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mWords.Data
{
    public static class ApplicationDbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.WordsDictionary.Any())
            {
                return;   // DB has been seeded
            }

            var words = new WordsDictionary[]
            {
                new WordsDictionary{English="cat", Polish="kot"},
                new WordsDictionary{English="dog", Polish="pies"},
                new WordsDictionary{English="duck", Polish="kaczka"},
            };

            foreach (WordsDictionary w in words)
            {
                context.WordsDictionary.Add(w);
            }
            context.SaveChanges();
        }
    }
}
