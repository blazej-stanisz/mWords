using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mWords.Models.EntityModels
{
    public class EntryAssignment
    {
        public EntryAssignment()
        {
            this.DictionaryEntry = new DictionaryEntry();
            this.ApplicationUser = new ApplicationUser<long>();
        }

        public long Id { get; set; }

        // foreign keys
        public int DictionaryEntryId { get; set; }

        public long ApplicationUserId { get; set; }

        // foreign objects

        public DictionaryEntry DictionaryEntry { get; set; }

        public ApplicationUser<long> ApplicationUser { get; set; }
    }
}
