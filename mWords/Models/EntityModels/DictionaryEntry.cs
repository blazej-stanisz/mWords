using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace mWords.Models.EntityModels
{
    public class DictionaryEntry
    {
        public DictionaryEntry()
        {
            this.DictionarySet = new DictionarySet();
        }

        public int Id { get; set; }

        public string Word { get; set; }

        public string Translation { get; set; }

        public string Pronunciation { get; set; }

        // foreign keys
        public int DictionarySetId { get; set; }

        // foreign objects
        public virtual DictionarySet DictionarySet { get; set; }
    }
}
