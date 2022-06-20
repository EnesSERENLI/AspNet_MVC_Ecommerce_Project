using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.BaseRepository;

namespace DAL.Entity
{
    public class Category:EntityRepository
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }

        public virtual List<SubCategory> SubCategories { get; set; }
    }
}
