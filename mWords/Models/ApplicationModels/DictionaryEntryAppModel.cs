using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mWords.Models.ApplicationModels
{
    public class DictionaryEntryAppModel
    {
        public long Id { get; set; }

        public string Word { get; set; }

        public string Translation { get; set; }

        public string Pronunciation { get; set; }
    }
}
