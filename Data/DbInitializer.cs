using EcommerceProject.Models.Entities;

namespace EcommerceProject.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Users.Any())
            {
                context.Users.Add(new User
                {
                    Username = "admin",
                    Password = "admin123", // Mật khẩu chính thức
                    FullName = "Quản Trị Viên",
                    Role = "Admin"
                });
                context.SaveChanges();
            }

            if (!context.Categories.Any())
            {
                var categories = new Category[]
                {
                    new Category { Name = "Điện thoại", Description = "Smartphone chính hãng" },
                    new Category { Name = "Laptop", Description = "Máy tính xách tay cao cấp" },
                    new Category { Name = "Phụ kiện", Description = "Tai nghe, sạc dự phòng, chuột" }
                };
                context.Categories.AddRange(categories);
                context.SaveChanges();

                var products = new Product[]
                {
                    new Product { Name = "iPhone 15 Pro Max", Price = 29990000, CategoryId = categories[0].Id, ImageUrl = "https://images.unsplash.com/photo-1695048133142-1a20484d2569?w=500", Description = "Flagship mới nhất từ Apple" },
                    new Product { Name = "Samsung Galaxy S24 Ultra", Price = 27990000, CategoryId = categories[0].Id, ImageUrl = "https://images.unsplash.com/photo-1610945265064-0e34e5519bbf?w=500", Description = "Quyền năng AI trong tay bạn" },
                    new Product { Name = "MacBook Pro M3 14 inch", Price = 39990000, CategoryId = categories[1].Id, ImageUrl = "https://images.unsplash.com/photo-1517336714731-489689fd1ca8?w=500", Description = "Hiệu năng đỉnh cao cho Creator" },
                    new Product { Name = "Tai nghe Sony WH-1000XM5", Price = 6490000, CategoryId = categories[2].Id, ImageUrl = "https://images.unsplash.com/photo-1505740420928-5e560c06d30e?w=500", Description = "Chống ồn hàng đầu thế giới" }
                };
                context.Products.AddRange(products);
                context.SaveChanges();
            }
        }
    }
}