using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace mWords.Models
{
    public class DictionaryEntry
    {
        public int Id { get; set; }

        public string Word { get; set; }

        public string Translation { get; set; }

        public string Pronunciation { get; set; }
    }
}
