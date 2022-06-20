using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class AppUserAndRole
    {
        public Guid AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
        public Guid AppUserRoleId { get; set; }
        public virtual AppUserRole AppUserRole { get; set; }
    }
}
