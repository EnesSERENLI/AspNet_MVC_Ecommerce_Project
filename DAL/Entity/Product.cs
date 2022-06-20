using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.BaseRepository;

namespace DAL.Entity
{
    public class Product : EntityRepository
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        public string ProductImagePath { get; set; }

        //Mapping
        public Guid SubCategoryId { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        public Guid SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }


    }
}
