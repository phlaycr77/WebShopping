using System.ComponentModel.DataAnnotations;

namespace EcommerceProject.Models.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên danh mục không được để trống")]
        [StringLength(100, ErrorMessage = "Tên danh mục không vượt quá 100 ký tự")]
        [Display(Name = "Tên danh mục")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Mô tả")]
        public string? Description { get; set; }

        // Quan hệ 1-N với Product
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}