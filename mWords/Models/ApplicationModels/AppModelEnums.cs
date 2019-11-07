using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace mWords.Models.ApplicationModels
{
    public class AppModelEnums
    {
        public enum DictionarySetStatus
        {
            [Description("Not Started")]
            NotStarted,

            [Description("In Progress")]
            InProgress,

            [Description("Finished")]
            Finished
        }
    }
}
