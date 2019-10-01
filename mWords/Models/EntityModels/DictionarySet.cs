using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mWords.Models.EntityModels
{
    public class DictionarySet
    {
        public DictionarySet()
        {
            this.DictionaryEntries = new HashSet<DictionaryEntry>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Level { get; set; }

        public string CoverColorHex { get; set; }

        // foreign objects
        public virtual ICollection<DictionaryEntry> DictionaryEntries { get; set; }
    }
}
