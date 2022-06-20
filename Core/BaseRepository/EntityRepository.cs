using Core.Enums;
using Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.BaseRepository
{
    public class EntityRepository : IEntity<Guid>
    {
        public EntityRepository()
        {
            Status = Status.Active; //The first added products will be active.
        }
        public Guid ID { get; set; }
        public int MasterID { get; set; }//ID that can be used to show the user
        public Status Status { get; set; }
        //When data is added
        public DateTime? CreatedDate { get; set; } //Nullable
        public string CreatedIP { get; set; } //Ip no
        public string CreatedComputerName { get; set; } //Which pc
        public string CreatedBy { get; set; } //Username
        public string CreatedAddUserName { get; set; } //Username logged into windows
        //When data is updated
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedIP { get; set; }
        public string UpdatedComputerName { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedAddUserName { get; set; }



    }
}
