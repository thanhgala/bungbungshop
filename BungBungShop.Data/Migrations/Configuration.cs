namespace BungBungShop.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Model.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BungBungShop.Data.BungBungShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BungBungShop.Data.BungBungShopDbContext context)
        {
            CreateProductCategorySample(context);
            CreateSlide(context);
            CreatePage(context);
            CreateContactDetail(context);
            //  This method will be called after migrating to the latest version.
            

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }

        private void CreateUser(BungBungShopDbContext context)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new BungBungShopDbContext()));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new BungBungShopDbContext()));

            var user = new ApplicationUser()
            {
                UserName = "gala",
                Email = "tabimtop@gmail.com",
                EmailConfirmed = true,
                BirthDay = DateTime.Now,
                FullName = "Do Xuan Thanh"
               
            };

            manager.Create(user, "gala12345A");

            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
                roleManager.Create(new IdentityRole { Name = "User" });
            }

            var adminUser = manager.FindByEmail("tabimtop@gmail.com");

            manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });

        }

        private void CreateProductCategorySample(BungBungShop.Data.BungBungShopDbContext context)
        {
            if (context.ProductCategories.Count() == 0)
            {
                List<ProductCategory> listProductCategory = new List<ProductCategory>()
                {
                    new ProductCategory() {Name="Điện lạnh",Alias="dien-lanh",Status = true },
                    new ProductCategory() { Name = "Viễn thông", Alias = "vien-thong", Status = true },
                    new ProductCategory() { Name = "Đồ gia dụng", Alias = "do-gia-dung", Status = true },
                    new ProductCategory() { Name = "Mỹ phẩm", Alias = "my-pham", Status = true }
                };
                context.ProductCategories.AddRange(listProductCategory);
                context.SaveChanges();
            }
        }

        private void CreateSlide(BungBungShopDbContext context)
        {
            if (context.Slides.Count() == 0)
            {
                List<Slide> listSlide = new List<Slide>()
                {
                    new Slide() {
                        Name ="Slide 1",
                        DisplayOrder = 1,
                        Status = true,
                        Url = "#" ,
                        Image = "/Assets/client/images/bag.jpg",
                        Content =@"	<h2>FLAT 50% 0FF</h2>
                                <label>FOR ALL PURCHASE <b>VALUE</b></label>
                                <p>Lorem ipsum dolor sit amet, consectetur 
                            adipisicing elit, sed do eiusmod tempor incididunt ut labore et </ p >
                        <span class=""on-get"">GET NOW</span>" },
                    new Slide() {
                        Name ="Slide 2",
                        DisplayOrder = 2,
                        Status = true,
                        Url = "#" ,
                        Image = "/Assets/client/images/bag1.jpg",
                        Content = @"<h2>FLAT 50% 0FF</h2>
                                <label>FOR ALL PURCHASE <b>VALUE</b></label>
                                <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et </ p >
                                <span class=""on-get"">GET NOW</span>" }
                };
                context.Slides.AddRange(listSlide);
                context.SaveChanges();
            }
        }

        private void CreatePage(BungBungShopDbContext context)
        {
            var page = new Page()
            {
                Name = "Giới thiệu",
                Alias = "gioi-thieu",
                Content = @"Được thành lập vào năm 1993, Công ty Cổ Phần Kỹ Thuật Toàn Thắng được biết đến như một  nhà cung cấp chuyên nghiệp các giải pháp thiết bị và dịch vụ kỹ thuật chất lượng cao, công nghệ tiên tiến cho khách hàng ngành dầu khí, điện lực và một số ngành công nghiệp nặng khác.
                Công ty có văn phòng chính tại TP.Hồ Chí Minh và một công ty con tại TP.Vũng Tàu.Với đội ngũ chuyên gia,
                kỹ sư được đào tạo chuyên sâu,
                chuyên trách từng mảng sản phẩm,
                chúng tôi luôn đem đến cho khách hàng những giải pháp kỹ thuật,
                thương mại đa dạng,
                đáp ứng tốt nhu cầu ngày càng cao của khách hàng.",
                Status = true
            };
            context.Pages.Add(page);
            context.SaveChanges();
        }

        private void CreateContactDetail(BungBungShopDbContext context)
        {
            var contact = new BungBungShop.Model.Models.ContactDetail()
            {
                Name = "Shop thời trang BungBung",
                Address = "15/1b khu phố 2 Bửu Long Biên Hòa Đồng Nai",
                Email = "tabimtop@gmail.com",
                Lat = 10.9555014,
                Lng = 106.7642442,
                Phone = "0909465745",
                Website = "http://galastudio.tk",
                Other = "",
                Status = true
            };
            context.ContactDetails.Add(contact);
            context.SaveChanges();
        }
    }
}