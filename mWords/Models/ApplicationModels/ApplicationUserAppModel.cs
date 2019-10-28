using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mWords.Models.ApplicationModels
{
    public class ApplicationUserAppModel
    {
        public virtual string SecurityStamp { get; set; }

        public virtual bool PhoneNumberConfirmed { get; set; }

        public virtual string PhoneNumber { get; set; }

        public virtual string PasswordHash { get; set; }

        public virtual string NormalizedUserName { get; set; }
        
        public virtual string NormalizedEmail { get; set; }
        
        public virtual DateTimeOffset? LockoutEnd { get; set; }
        
        public virtual bool LockoutEnabled { get; set; }
        
        //public virtual TKey Id { get; set; }
        
        public virtual bool EmailConfirmed { get; set; }
        
        public virtual string Email { get; set; }
        
        public virtual string ConcurrencyStamp { get; set; }
        
        public virtual int AccessFailedCount { get; set; }
        
        public virtual bool TwoFactorEnabled { get; set; }
        
        public virtual string UserName { get; set; }


        public ICollection<EntryAssignmentAppModel> EntryAssignments { get; set; }
    }
}
