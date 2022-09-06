using Microsoft.EntityFrameworkCore;
using MyEshop_2.Models;

namespace MyEshop_2.Data
{
    public class MyEshopContext2 : DbContext
    {

        public MyEshopContext2(DbContextOptions<MyEshopContext2> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CategoryToProduct>().HasKey(
                e => new 
                {
                    e.CategoryId , e.ProductId
                }
                );

            modelBuilder.Entity<Item>(
                c=> 
                {
                    c.HasKey(w => w.id);
                    c.Property(o => o.price).HasColumnType("money");
                }
                );

            modelBuilder.Entity<OrderDetails>(

                u =>
                {
                    u.HasKey(i => i.DetailId);
                    u.Property(r => r.Price).HasColumnType("money");
                });
               

            //modelBuilder.Entity<Product>(
            //    p =>
            //    {
            //        p.HasKey(w => w.id);
            //        p.OwnsOne<Item>(w=>w.Item);
            //        p.HasOne<Item>(w => w.Item).WithOne(w => w.Product)
            //        .HasForeignKey<Item>(w => w.id);
            //    });

            #region Seed Data
            modelBuilder.Entity<Category>().HasData(
                new Category()
                {

                    id = 1,
                    name = "کالای دیجیتال",
                 Description = "محصولات حوزه دیجیتال مانند گوشی و تبلت و لپتاپ",


                },
            new Category()
            {
                id = 2,
                name = "لوازم کامپیوتر",
                 Description ="لوازم جانبی ابزار کامپیوتر"
            },
            new Category()
            {
                id = 3,
                name = "لوازم عکاسی",
                 Description =" تمامی لوازم مورد نیاز شما برای عکاسی حرفه ای"
            },

              new Category()
              {
                  id = 4,
                  name = "صوتی تصویری",
                 Description ="کلیه لوازم صوتی تصویری خانه خود را از ما بخواهید"
            });


            modelBuilder.Entity<Product>().HasData(
                 new Product
                {
                     id=1,
                     ItemId= 1,
                    Name="گوشی سامسونگ s7 edge",
                     Description="گوشی سامسونگ گلکسی s7 edge پرچمدار سابق سامسونگ که هنوز هم حرف های زیادی برای گفتن دارد"
                },
                  new Product
                  {
                      id=2,
                      ItemId= 2,
                      Name ="موس گرین GM 402",
                      Description = "موس گیمینگ گرین مدل GM 402 دارای رنگ های rgb  و کلید های بک و فوروارد در دو طرف میباشد...این موس دارای 24 ماه گارانتی گرین می باشد"
                  },
                   new Product
                   {
                       id=3,
                       ItemId=3,
                       Name = "دوربین کانن 5d",
                       Description = "کانن 5D مارک ۴ برای عکاسانی ساخته شده که می‌خواهند بهترین دوربین همه‌کاره‌ی این شرکت را داشته باشند. دوربینی مجهز به پیشرفته‌ترین سنسور تصویری که کانن تا سال ۲۰۱۶ ساخته و امکاناتی که باعث شده این دوربین تا چهار سال دیگر در کورس رقابت برترین‌ دوربین‌های DSLR فول‌ُفریم باقی بماند."
                   },
                    new Product
                    {
                        id=4,
                        ItemId=4,
                        Name = "تلویزیون ال ای دی هوشمند سونی مدل 65X85J سایز 65 اینچ",
                        Description = "تلویزیون ال ای دی هوشمند سونی مدل 65X85J سایز 65 اینچ تلویزیونی مناسب برای تماشای برنامه های تلویزیونی و اینترنتی شما میباشد. این تلویزیون دارای دو درگاه USB آن هم به شما امکان پخش تصاویر و ویدیو های داخل حافظه های جانبی شما را با کیفیت 4K می‌دهد."
                    }
                );
            modelBuilder.Entity<Item>().HasData(
                new Item
                {
                    id=1,
                    price=5M,
                     QuantityinStock =0,
                     
                },
                new Item
                {
                    id = 2,
                    price = 300000,
                    QuantityinStock = 100,
                },
                new Item
                {
                    id = 3,
                    price = 55.600000M,
                    QuantityinStock = 3,
                },
                new Item
                {
                    id = 4,
                    price = 50.980000M,
                    QuantityinStock = 4,
                }
                );

            modelBuilder.Entity<CategoryToProduct>().HasData(
                new CategoryToProduct { ProductId = 1, CategoryId =1 },
                new CategoryToProduct { ProductId =1 , CategoryId =2 },
                new CategoryToProduct { ProductId = 2, CategoryId =2 },

                new CategoryToProduct { ProductId = 2, CategoryId =4 },
                new CategoryToProduct { ProductId = 3, CategoryId =3 },
                new CategoryToProduct { ProductId = 3, CategoryId = 4},
                new CategoryToProduct { ProductId =4 , CategoryId =4 },
                new CategoryToProduct { ProductId = 4, CategoryId = 1},
                new CategoryToProduct { ProductId = 2, CategoryId =3},
                new CategoryToProduct { ProductId = 2, CategoryId =1 }
                

                );

            #endregion
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<CategoryToProduct> categoryToProducts { get; set; }

        public DbSet<Item> Item { get; set; }

        public DbSet<Users> Users { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetails> OrderDetails { get; set; }
    }
}
