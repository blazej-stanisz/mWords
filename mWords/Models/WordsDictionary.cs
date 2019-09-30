using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace mWords.Models
{
    public class WordsDictionary
    {
        public int Id { get; set; }

        public string English { get; set; }

        public string Polish { get; set; }

        public string Pronunciation { get; set; }
    }
}
