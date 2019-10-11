using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mWords.Models.EntityModels
{
    /// <summary>
    /// The representation of dictionary set. The set of dictionary entries.
    /// </summary>
    public class DictionarySet
    {
        public DictionarySet()
        {
            this.DictionaryEntries = new HashSet<DictionaryEntry>();
        }

        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string LanguagesPair { get; set; }

        public string Level { get; set; }

        public string LevelDescription { get; set; }

        public string CoverColorHex { get; set; }

        // foreign objects
        public ICollection<DictionaryEntry> DictionaryEntries { get; set; }
    }
}
