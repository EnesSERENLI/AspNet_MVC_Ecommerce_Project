using Core.Map;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Map
{
    public class AppUserMap:CoreMap<AppUser>
    {
        public AppUserMap()
        {
            ToTable("dbo.AppUsers");
            Property(x => x.FirstName).HasMaxLength(255).IsOptional();
            Property(x => x.LastName).HasMaxLength(255).IsOptional();
            Property(x => x.Address).HasMaxLength(255).IsOptional();
            Property(x => x.UserName).HasMaxLength(255).IsRequired();
            Property(x => x.Password).HasMaxLength(255).IsRequired();
            Property(x => x.Email).HasMaxLength(255).IsRequired();
        }
    }
}
