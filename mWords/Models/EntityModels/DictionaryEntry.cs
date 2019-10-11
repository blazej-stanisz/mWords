using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace mWords.Models.EntityModels
{
    /// <summary>
    /// The representation of entry in words dictionary
    /// </summary>
    public class DictionaryEntry
    {
        public DictionaryEntry()
        {
            this.DictionarySet = new DictionarySet();
            this.EntryAssignments = new HashSet<EntryAssignment>();
        }

        public int Id { get; set; }

        public string Word { get; set; }

        public string Translation { get; set; }

        public string Pronunciation { get; set; }

        // foreign keys
        public int DictionarySetId { get; set; }

        // foreign objects
        public DictionarySet DictionarySet { get; set; }

        public ICollection<EntryAssignment> EntryAssignments { get; set; }
    }
}
