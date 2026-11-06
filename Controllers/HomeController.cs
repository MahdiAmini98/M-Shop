using System.Diagnostics;
using System.Security.Claims;
using M_Shop.Data;
using Microsoft.AspNetCore.Mvc;
using M_Shop.Models;
using M_Shop.Models.View_Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace M_Shop.Controllers
{
    public class HomeController : Controller
    {

        private MShop_DBContext _context;



        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, MShop_DBContext context)
        {
            _logger = logger;
            _context = context;
        }

        #region Index

        //این کنترلر صفحه اصلی سایت را بالا میاورد
        public IActionResult Index(string Search = "")
        {
            List<Product> product = new();
            if (string.IsNullOrEmpty(Search))
            {
                 product = _context.Products.ToList();
            }
            else
            {
                product = _context.Products.Where(x => x.Name.Equals(Search)).ToList();
            }
                return View(product);
        }
        #endregion

        #region ContactUs

        //وظیفه این کنترلر ایجاد صقحه تماس با ما است
        [Route("ContactUs")]
        public IActionResult ContactUs()
        {
            return View();
        }

        #endregion

        #region Detail

        //صفحه جزییات محصولات
        public IActionResult Detail(int id)
        {
            var product = _context.Products
                .Include(e => e.Item).SingleOrDefault(i => i.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            var category = _context.Products.Where(p => p.Id == id)
                .SelectMany(c => c.CategoryToProducts).Select(d => d.Category).ToList();

            var detail_vm = new DetailViewModel()
            {
                Product = product,
                Categories = category
            };

            return View(detail_vm);
        }

        #endregion


        #region Cart

        //اضافه کردن محصول به سبد خرید

        [Authorize]
        public IActionResult AddToCart(int itemId)
        {

            var product = _context.Products.Include(p => p.Item)
                .SingleOrDefault(c => c.ItemId == itemId);
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
            var order = _context.Orders.FirstOrDefault(o => o.UserId == userId && !o.IsFinaly);


            if (order != null)
            {

                var orderDetail = _context.OrderDetails.FirstOrDefault(o => o.OrderId == order.OrderId && o.ProductId == product.Id);

                if (orderDetail != null)
                {
                    orderDetail.Count += 1;
                }
                else
                {
                    _context.OrderDetails.Add(new OrderDetail()
                    {
                        OrderId = order.OrderId,
                        ProductId = product.Id,
                        Price = product.Item.Price,
                        Count = 1
                    });
                }


            }
            else
            {
                order = new Order()
                {
                    UserId = userId,
                    CreateData = DateTime.Now,
                    IsFinaly = false

                };

                _context.Orders.Add(order);
                _context.SaveChanges();
                _context.OrderDetails.Add(new OrderDetail()
                {

                    OrderId = order.OrderId,
                    ProductId = product.Id,
                    Price = product.Item.Price,
                    Count = 1
                });
                _context.SaveChanges();
            }

            _context.SaveChanges();
            return RedirectToAction("ShowCart");



        }

        //نمایش سبد خرید

        [Authorize]
        public IActionResult ShowCart()
        {

            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
            var order = _context.Orders.Where(o => o.UserId == userId && !o.IsFinaly)
                .Include(o => o.OrderDetails)
                .ThenInclude(c => c.Product).FirstOrDefault();
            return View(order);
        }


        [Authorize]
        public IActionResult RemoveToCart(int detailId)
        {
            var orderDetail = _context.OrderDetails.Find(detailId);
            if (orderDetail.Count == 1)
            {
                _context.OrderDetails.Remove(orderDetail);
                _context.SaveChanges();
            }
            else
            {
                orderDetail.Count -= 1;
            }

            _context.SaveChanges();

            return RedirectToAction("ShowCart");
        }


        #endregion

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
