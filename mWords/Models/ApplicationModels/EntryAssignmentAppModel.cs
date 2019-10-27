using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mWords.Models.ApplicationModels
{
    public class EntryAssignmentAppModel
    {
        public long Id { get; set; }

        public DateTime AttemptDate { get; set; }

        public byte Pigeonhole { get; set; }


        // foreign keys
        public long DictionaryEntryId { get; set; }


        // foreign objects

        public DictionaryEntryAppModel DictionaryEntry { get; set; }
    }
}
