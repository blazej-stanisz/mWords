﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static mWords.Models.ApplicationModels.AppModelEnums;

namespace mWords.Models.ApplicationModels
{
    public class DictionarySetAppModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string LanguagesPair { get; set; }

        public string Level { get; set; }

        public string LevelDescription { get; set; }

        public string CoverColorHex { get; set; }

        // view properties
        public DictionarySetStatus Status { get; set; }

        public int Progress { get; set; }
    }
}
