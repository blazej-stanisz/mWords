using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mWords.Models.EntityModels
{
    public class ApplicationUser<T> : IdentityUser<T> where T : IEquatable<T>
    {
        public ApplicationUser()
        {
            this.EntryAssignments = new HashSet<EntryAssignment>();
        }

        //public string DisplayedName { get; set; }

        public ICollection<EntryAssignment> EntryAssignments { get; set; }
    }
}
