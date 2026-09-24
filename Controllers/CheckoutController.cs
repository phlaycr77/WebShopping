using EcommerceProject.Data;
using EcommerceProject.Helpers;
using EcommerceProject.Models.Entities;
using EcommerceProject.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceProject.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly ApplicationDbContext _context;
        private const string CART_KEY = "CartSession";

        public CheckoutController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItemViewModel>>(CART_KEY);
            if (cart == null || !cart.Any())
            {
                return RedirectToAction("Index", "Cart");
            }
            return View(new CheckoutViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(CheckoutViewModel model)
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItemViewModel>>(CART_KEY);
            if (cart == null || !cart.Any())
            {
                return RedirectToAction("Index", "Cart");
            }

            if (ModelState.IsValid)
            {
                var order = new Order
                {
                    CustomerName = model.CustomerName,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address,
                    Note = model.Note,
                    OrderDate = DateTime.Now,
                    Status = "Chờ xử lý"
                };

                _context.Orders.Add(order);
                await _context.SaveChangesAsync();

                foreach (var item in cart)
                {
                    _context.OrderDetails.Add(new OrderDetail
                    {
                        OrderId = order.Id,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        UnitPrice = item.Price
                    });
                }

                await _context.SaveChangesAsync();
                HttpContext.Session.Remove(CART_KEY); // Làm sạch giỏ hàng

                return RedirectToAction("Success", new { orderId = order.Id });
            }

            return View(model);
        }

        public IActionResult Success(int orderId)
        {
            ViewBag.OrderId = orderId;
            return View();
        }
    }
}