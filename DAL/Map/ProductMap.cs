using Core.Map;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Map
{
    public class ProductMap:CoreMap<Product>
    {
        public ProductMap()
        {
            ToTable("dbo.Products");
            Property(x => x.ProductName).IsRequired().HasMaxLength(255);
            Property(x => x.ProductImagePath).IsOptional().HasMaxLength(500);
            Property(x => x.Description).IsOptional().HasMaxLength(2000);
        }
    }
}
