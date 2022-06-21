using Common;
using Core.BaseRepository;
using DAL.Entity;
using DAL.Map;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class ECommerceContext:DbContext
    {
        public ECommerceContext()
        {
            Database.Connection.ConnectionString = "server=DESKTOP-JOE5KI8\\SQLEXPRESS02;Database=E-CommerceDB;Trusted_Connection=True;";
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppUserRole> AppUserRoles { get; set; }
        public DbSet<AppUserAndRole> AppUserAndRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Fluent Api
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new SupplierMap());
            modelBuilder.Configurations.Add(new SubCategoryMap());
            modelBuilder.Configurations.Add(new AppUserMap());
            modelBuilder.Configurations.Add(new AppUserRoleMap());

            modelBuilder.Entity<AppUserAndRole>().HasKey(x => new
            {
                x.AppUserId,
                x.AppUserRoleId
            });
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            var modifiedEntities = ChangeTracker.Entries()
                .Where(x=>x.State == EntityState.Added ||
                x.State == EntityState.Modified ||
                x.State == EntityState.Deleted)
                .ToList();
            string computerName = Environment.MachineName;

            string ipAdress = RemoteIpAdress.GetIpAdress();

            DateTime date = DateTime.Now;

            foreach (var item in modifiedEntities)
            {
                EntityRepository entity = item.Entity as EntityRepository;
                if (item != null)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            entity.CreatedDate = date;
                            entity.CreatedComputerName = computerName;
                            entity.CreatedIP = ipAdress;
                            entity.Status = Core.Enums.Status.Active;
                            break;
                        case EntityState.Modified:
                            entity.UpdatedDate = date;
                            entity.UpdatedComputerName = computerName;
                            entity.UpdatedIP = ipAdress;
                            if (entity.Status == Core.Enums.Status.Deleted)
                            {
                                entity.Status = Core.Enums.Status.Deleted;
                            }
                            else
                            {
                                entity.Status = Core.Enums.Status.Updated;
                            }
                            break;
                    }
                }
            }
            return base.SaveChanges();
        }
    }
}
