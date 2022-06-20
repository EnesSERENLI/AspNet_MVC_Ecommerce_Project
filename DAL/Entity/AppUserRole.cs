using Core.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class AppUserRole:EntityRepository
    {
        public string RoleName { get; set; }
        public virtual List<AppUserAndRole> AppUserAndRoles { get; set; }
    }
}
