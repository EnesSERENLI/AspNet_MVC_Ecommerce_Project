namespace DAL.Migrations
{
    using DAL.Entity;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.Context.ECommerceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DAL.Context.ECommerceContext context)
        {

            //todo: Her bir ürüne ait görseller için UI katman içerisinde content/product isminde klasör oluşturulup içerisine var sayılan görseller eklenecek.
            //Categories
            List<Category> categories = new List<Category>()
            {
                new Category{ID = Guid.NewGuid(),CategoryName="Teknoloji",Description="Teknolojik Ürünler"},
                new Category{ID = Guid.NewGuid(),CategoryName="Giyim",Description="Yazlık kışlık son moda giyim ürünleri"},
                new Category{ID = Guid.NewGuid(),CategoryName="Kitap",Description="Tarih,Edebiyat,Kişisel Gelişim vs..."},
                new Category{ID = Guid.NewGuid(),CategoryName="Kozmetik",Description="Kozmetik Ürünleri"}
            };
            if (!context.Categories.Any())
            {
                foreach (var category in categories)
                {
                    context.Categories.Add(category);
                    context.SaveChanges();
                }
            }
            //SubCategories
            List<SubCategory> subCategories = new List<SubCategory>()
            {
                new SubCategory{ID = Guid.NewGuid(),SubCategoryName="Bilgisayar",CategoryId=categories.FirstOrDefault(x=>x.CategoryName == "Teknoloji").ID},
                new SubCategory{ID = Guid.NewGuid(),SubCategoryName="Televizyon",CategoryId=categories.FirstOrDefault(x=>x.CategoryName == "Teknoloji").ID},
                new SubCategory{ID = Guid.NewGuid(),SubCategoryName="Telefon",CategoryId=categories.FirstOrDefault(x=>x.CategoryName == "Teknoloji").ID},
                new SubCategory{ID = Guid.NewGuid(),SubCategoryName="Tshirt",CategoryId=categories.FirstOrDefault(x=>x.CategoryName == "Giyim").ID},
                new SubCategory{ID = Guid.NewGuid(),SubCategoryName="Ayakkabı",CategoryId=categories.FirstOrDefault(x=>x.CategoryName == "Giyim").ID},
                new SubCategory{ID = Guid.NewGuid(),SubCategoryName="Jean",CategoryId=categories.FirstOrDefault(x=>x.CategoryName == "Giyim").ID},
                new SubCategory{ID = Guid.NewGuid(),SubCategoryName="Roman",CategoryId=categories.FirstOrDefault(x=>x.CategoryName == "Kitap").ID},
                new SubCategory{ID = Guid.NewGuid(),SubCategoryName="Edebiyat",CategoryId=categories.FirstOrDefault(x=>x.CategoryName == "Kitap").ID},
                new SubCategory{ID = Guid.NewGuid(),SubCategoryName="Felsefe",CategoryId=categories.FirstOrDefault(x=>x.CategoryName == "Kitap").ID},
                new SubCategory{ID = Guid.NewGuid(),SubCategoryName="Parfüm",CategoryId=categories.FirstOrDefault(x=>x.CategoryName == "Kozmetik").ID},
                new SubCategory{ID = Guid.NewGuid(),SubCategoryName="Eyeliner",CategoryId=categories.FirstOrDefault(x=>x.CategoryName == "Kozmetik").ID},
                new SubCategory{ID = Guid.NewGuid(),SubCategoryName="Fonfoten",CategoryId=categories.FirstOrDefault(x=>x.CategoryName == "Kozmetik").ID},
                new SubCategory{ID = Guid.NewGuid(),SubCategoryName="Ruj",CategoryId=categories.FirstOrDefault(x=>x.CategoryName == "Kozmetik").ID}
            };
            if (!context.SubCategories.Any())
            {
                foreach (var subCategory in subCategories)
                {
                    context.SubCategories.Add(subCategory);
                    context.SaveChanges();
                }
            }
            //Suppliers
            List<Supplier> suppliers = new List<Supplier>()
            {
                new Supplier{ID = Guid.NewGuid(), CompanyName="Gello Cosmatics", Address="İstanbul"},
                new Supplier{ID = Guid.NewGuid(), CompanyName="Demir Lojistik Tic", Address="İstanbul"},
                new Supplier{ID = Guid.NewGuid(), CompanyName="Kuzey yeli deposu Tic", Address="İstanbul"},
                new Supplier{ID = Guid.NewGuid(), CompanyName="Teknosa", Address="İstanbul"}
            };
            if (!context.Suppliers.Any())
            {
                foreach (var supplier in suppliers)
                {
                    context.Suppliers.Add(supplier);
                    context.SaveChanges();
                }
            }
            //Products
            List<Product> products = new List<Product>()
            {
                new Product{ID = Guid.NewGuid(), ProductName="MSI",SubCategoryId=subCategories.FirstOrDefault(x=>x.SubCategoryName =="Bilgisayar").ID,SupplierId=suppliers.FirstOrDefault(x=>x.CompanyName =="Teknosa").ID,UnitsInStock=50,UnitPrice=15000,Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed eleifend dignissim ultricies. Ut congue, sapien eget molestie semper, massa nulla convallis lacus, a fringilla erat augue nec est. Duis a blandit arcu, in laoreet ipsum. Nunc nec maximus mauris, quis maximus tellus. Vivamus efficitur nunc lorem, vel suscipit orci convallis a. Quisque eget mi dolor. Proin ullamcorper sapien magna, vel consequat ante sodales interdum. Nulla id augue nulla. "},
                new Product{ID = Guid.NewGuid(), ProductName="Arçelik LCD",SubCategoryId=subCategories.FirstOrDefault(x=>x.SubCategoryName =="Televizyon").ID,SupplierId=suppliers.FirstOrDefault(x=>x.CompanyName =="Demir Lojistik Tic").ID,UnitsInStock=150,UnitPrice=20000,Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed eleifend dignissim ultricies. Ut congue, sapien eget molestie semper, massa nulla convallis lacus, a fringilla erat augue nec est. Duis a blandit arcu, in laoreet ipsum. Nunc nec maximus mauris, quis maximus tellus. Vivamus efficitur nunc lorem, vel suscipit orci convallis a. Quisque eget mi dolor. Proin ullamcorper sapien magna, vel consequat ante sodales interdum. Nulla id augue nulla. "},
                new Product{ID = Guid.NewGuid(), ProductName="Iphone 13 Pro Max",SubCategoryId=subCategories.FirstOrDefault(x=>x.SubCategoryName =="Telefon").ID,SupplierId=suppliers.FirstOrDefault(x=>x.CompanyName =="Kuzey yeli deposu Tic").ID,UnitsInStock=150,UnitPrice=30000,Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed eleifend dignissim ultricies. Ut congue, sapien eget molestie semper, massa nulla convallis lacus, a fringilla erat augue nec est. Duis a blandit arcu, in laoreet ipsum. Nunc nec maximus mauris, quis maximus tellus. Vivamus efficitur nunc lorem, vel suscipit orci convallis a. Quisque eget mi dolor. Proin ullamcorper sapien magna, vel consequat ante sodales interdum. Nulla id augue nulla. "}
            };
            if (!context.Products.Any())
            {
                foreach (var product in products)
                {
                    context.Products.Add(product);
                    context.SaveChanges();
                }
            }
            //AppUser
            List<AppUser> userList = new List<AppUser>()
            {
                new AppUser{ID=Guid.NewGuid(),UserName="enes",Password="1234",Email="enes.serenli@hotmail.com",ConfirmEmail=true}
            };
            if (!context.AppUsers.Any())
            {
                foreach (var user in userList)
                {
                    context.AppUsers.Add(user);
                    context.SaveChanges();
                }
            }

            //AppUserRole
            List<AppUserRole> userRoles = new List<AppUserRole>
            {
                new AppUserRole{ID=Guid.NewGuid(),RoleName="admin"},
                new AppUserRole{ID=Guid.NewGuid(),RoleName="moderatör"},
                new AppUserRole{ID=Guid.NewGuid(),RoleName="member"}
            };

            if (!context.AppUserRoles.Any())
            {
                foreach (var role in userRoles)
                {
                    context.AppUserRoles.Add(role);
                    context.SaveChanges();
                }
            }

            List<AppUserAndRole> userAndRoles = new List<AppUserAndRole>
            {
                new AppUserAndRole
                {
                    AppUserId = context.AppUsers.FirstOrDefault(x => x.UserName == "enes").ID,
                    AppUserRoleId = context.AppUserRoles.FirstOrDefault(x => x.RoleName == "admin").ID
                }
            };
            //AppUserAndRole
            if (!context.AppUserAndRoles.Any())
            {
                foreach (var item in userAndRoles)
                {
                    context.AppUserAndRoles.Add(item);
                    context.SaveChanges();
                }
            }
        }
    }
}
