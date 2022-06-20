using Core.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class AppUser : EntityRepository
    {
        public AppUser()
        {
            ConfirmEmail = false; //When the user first registers, the status should be false until confirmation from the e-mail address.
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool ConfirmEmail { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }        

        public virtual List<AppUserAndRole> AppUserAndRoles { get; set; }
    }
}
