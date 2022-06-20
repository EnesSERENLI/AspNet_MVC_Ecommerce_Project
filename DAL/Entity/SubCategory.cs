using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.BaseRepository;

namespace DAL.Entity
{
    public class SubCategory:EntityRepository
    {
        public string SubCategoryName { get; set; }
        public string Description { get; set; }

        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
