using Microsoft.AspNetCore.Mvc;
using MyEshop_2.Data;

namespace MyEshop_2.Controllers
{
    public class ProductController : Controller
    {
        private MyEshopContext2 _context;
        public ProductController( MyEshopContext2 context)
        {
            _context = context;
        }
        [Route("/Group/{id}/{name}")]
        public IActionResult ShowProductByGroup(int id, string name)
        {

            ViewData["GroupName"]=name;
            var product = _context.Products.SelectMany(c => c.CategoryToProducts)
                .Where(ca => ca.CategoryId == id).Select(e => e.Product);
            return View(product);
        }
    }
}
