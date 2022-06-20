using Core.Map;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Map
{
    public class AppUserRoleMap:CoreMap<AppUserRole>
    {
        public AppUserRoleMap()
        {
            ToTable("dbo.AppUserRoles");
            Property(x => x.RoleName).IsRequired().HasMaxLength(255);
        }
    }
}
