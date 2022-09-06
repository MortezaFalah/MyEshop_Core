using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyEshop_2.Data;
using MyEshop_2.Models;

namespace MyEshop_2.Pages.Admin
{
    public class DeleteModel : PageModel
    {
        private MyEshopContext2 _context;

        public DeleteModel(MyEshopContext2 context)
        {
            _context = context;
          
        }

        [BindProperty]
        public Product Product { get; set; }
        public void OnGet(int id)
        {
            Product = _context.Products.Where(t=>t.id==id).Include(o => o.Item).FirstOrDefault();
        }

        public IActionResult OnPost()
        {
            var pro = _context.Products.Find(Product.id);
            var item = _context.Item.Find(pro.ItemId);

            _context.Products.Remove(pro);
            _context.Item.Remove(item);
            _context.SaveChanges();

            string filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", pro.id + ".jpg");

            if (System.IO.File.Exists(filepath))
            {
                System.IO.File.Delete(filepath);
            }

            


            return RedirectToPage("Index");

        }
    }
}
