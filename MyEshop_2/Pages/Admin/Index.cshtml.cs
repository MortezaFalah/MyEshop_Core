using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyEshop_2.Data;
using MyEshop_2.Models;

namespace MyEshop_2.Pages.Admin
{
    public class IndexModel : PageModel
    {
        public IEnumerable<Product> Products { get; set; }

        private MyEshopContext2 _context;

        public IndexModel(MyEshopContext2 context2)
        {
            _context = context2;
        }
        public void OnGet()
        {
            Products = _context.Products.Include(w=>w.Item);
        }


        public void OnPost()
        {
        }
    }
}
