# HỆ THỐNG WEBSITE GIỚI THIỆU SẢN PHẨM VÀ ĐẶT HÀNG

Dự án được xây dựng trên nền tảng **ASP.NET Core MVC** kết hợp với **Entity Framework Core** và **SQL Server**.

## 🛠 Hướng dẫn Cấu hình & Chạy Dự án

### 1. Chuẩn bị Cơ sở dữ liệu
1. Mở file `appsettings.json`.
2. Thay đổi chuỗi kết nối `DefaultConnection` cho phù hợp với máy của bạn:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=EcommerceDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
   }