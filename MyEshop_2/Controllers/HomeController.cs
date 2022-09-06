using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyEshop_2.Data;
using MyEshop_2.Models;
using System;
using System.Diagnostics;
using System.Security.Claims;
using ZarinpalSandbox;

namespace MyEshop_2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MyEshopContext2 _context;

      
        public HomeController(ILogger<HomeController> logger,MyEshopContext2 context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var Product = _context.Products.ToList();
            return View(Product);
        }
        [Route("ContactUs")]
        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult Detail(int id)
        {

            var Product = _context.Products.
                Include(r=>r.Item).SingleOrDefault(e=>e.id==id);

            if (Product == null)
            {
                return NotFound();
            }
            var Category = _context.Products.Where(c => c.id == id)
                .SelectMany(r => r.CategoryToProducts).Select(ca => ca.Category).ToList();

            DetailViewModel dt = new DetailViewModel()
            {
              Product = Product,
              categories = Category
            };
            return View(dt);
        }

        [Authorize]
        public IActionResult AddToCart(int itemid)
        {
            var Product = _context.Products.Include(r => r.Item).SingleOrDefault(t => t.ItemId == itemid);

            if (Product == null)
                return NotFound();
            int userdi = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
            var order = _context.Orders.SingleOrDefault(u => u.UserId == userdi && !u.IsFinaly);
            if (order!=null)
            {
                var orderDetail= _context.OrderDetails.SingleOrDefault(
                    u => u.OrderId ==order.OrderId && u.ProductId==Product.id);
                if(orderDetail!=null)
                {
                    orderDetail.Count += 1;
                }
                else
                {
                    OrderDetails ord = new OrderDetails()
                    {
                         Count = 1,
                          ProductId = Product.id,
                           OrderId = order.OrderId,
                            Price = Product.Item.price,

                    };
                    _context.OrderDetails.Add(ord);
                }
                
            }
            else
            {
                Order neword = new Order()
                {
                     UserId = userdi,
                      IsFinaly = false,
                       CreateDate = DateTime.Now      
                };
                _context.Orders.Add(neword);
                _context.SaveChanges();

                OrderDetails orderDetails = new OrderDetails()
                {
                     Count = 1,
                      OrderId = neword.OrderId,
                       Price = Product.Item.price,
                        ProductId = Product.id,
                };

            }

            _context.SaveChanges();
            return RedirectToAction("ShowCart");
        }


        public IActionResult ShowCart()
        {
            int userid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
            var order = _context.Orders.Where(o => o.UserId == userid && !o.IsFinaly).
                Include(r => r.OrderDetails).ThenInclude(p => p.product).FirstOrDefault();
            return View(order);
        }


        public IActionResult PayMent()
        {
            var order = _context.Orders.Where(u => !u.IsFinaly).Include(t => t.OrderDetails).FirstOrDefault();
            if (order == null)
                return NotFound();

            var payment = new Payment(Convert.ToInt32(order.OrderDetails.Sum(r => r.Price * r.Count)));
            var res = payment.PaymentRequest($"پرداخت فاکتور شماره{order.OrderId} ",
                "https://localhost:7178/Home/OnlinePayment/"+ order.OrderId,"Morteza.f78@gmail.com","09116307457"
                ); 
            if(res.Result.Status == 100)
            {
                return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + res.Result.Authority);
            }
            else
            {
                return BadRequest();
            }

            return null;

        }


        public IActionResult OnlinePayment(int id)
        {
            if (HttpContext.Request.Query["Status"] != "" &&
                HttpContext.Request.Query["Status"].ToString().ToLower() =="ok" &&
                HttpContext.Request.Query["Authority"] != "")
            {
                string Authority = HttpContext.Request.Query["Authority"].ToString();
                var order = _context.Orders.Include(i=>i.OrderDetails) .FirstOrDefault(e=>e.OrderId == id);
                var payment = new Payment(Convert.ToInt32(order.OrderDetails.Sum(t => t.Price * t.Count)));
                var res = payment.Verification(Authority).Result;

                if(res.Status == 100)
                {
                    order.IsFinaly = true;
                    _context.Orders.Update(order);
                    _context.SaveChanges();
                    ViewBag.code = res.RefId;
                    return View();
                }

               
            }
            return NotFound();
        }

        public IActionResult RemoveProduct(int DetailId)
        {
            var detailid = _context.OrderDetails.Find(DetailId);
            //if (_cart.CartItems.Exists(p => p.Item.id == product.ItemId))
            //{
            //    _cart.RemoveItem(product.ItemId);
            //}
            //else if (_cart.CartItems.Exists(p => p.Item.id == product.ItemId)) ;
            //if(product == null)
            //{
            //    return NotFound();
            //}
            if(detailid.Count > 1)
            {
                detailid.Count -= 1;
            }
            else
            {
                _context.OrderDetails.Remove(detailid);
            }
           
            _context.SaveChanges();


            return RedirectToAction("ShowCart");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}