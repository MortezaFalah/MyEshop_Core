using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyEshop_2.Data;
using MyEshop_2.Models;

namespace MyEshop_2.Pages.Admin
{
    public class EditModel : PageModel
    {
        private MyEshopContext2 _context;

        public EditModel(MyEshopContext2 context)
        {
            _context = context;
           
        }

        [BindProperty]
        public AddOrEditProductViewModel Product { get; set; }

        [BindProperty]
        public List<int> SelectedGroups { get; set; }
        public List<int> ProductGroups { get; set; }

        public void OnGet(int id)
        {
            var pro = _context.Products.Where(r => r.id == id).Include(o => o.Item)
                .Select (t=> new AddOrEditProductViewModel
                {
                    Description = t.Description,
                    Name = t.Name,
                    Price = t.Item.price,
                    QuantityinStock = t.Item.QuantityinStock,
                     Id = t.id,
                     Categories = _context.Categories.ToList()

                }).FirstOrDefault();


            Product = pro;

            var gr = _context.categoryToProducts.Where(r => r.ProductId == id).Select(e => e.CategoryId).ToList();
            ProductGroups = gr;

          
            

        }

        public IActionResult OnPost()
        {
            if (ModelState!.IsValid)
            {
                return Page();
            }
            var pro = _context.Products.Find(Product.Id);
            var item = _context.Item.Find(pro.ItemId);

            pro.Name = Product.Name;
            pro.Description = Product.Description;

            item.price = Product.Price;
            item.QuantityinStock = Product.QuantityinStock;
            _context.SaveChanges();


            string FilePath = Path.Combine(Directory.GetCurrentDirectory(),
                   "wwwroot", "Images", pro.id + ".jpg");

            if (System.IO.File.Exists(FilePath).ToString() != pro.id + ".jpg")
            {


                if (Product.Picture?.Length > 0)
                {

                    using (var stream = new FileStream(FilePath, FileMode.Create))
                    {
                        Product.Picture.CopyTo(stream);
                    }
                }

            }

            _context.categoryToProducts.Where(t => t.ProductId == pro.id).ToList()
                .ForEach(u => _context.categoryToProducts.Remove(u));

            if (SelectedGroups.Any() && SelectedGroups.Count > 0)
            {
                foreach (int gr in SelectedGroups)
                {
                    var cat = new CategoryToProduct()
                    {
                        CategoryId = gr,
                        ProductId = pro.id
                    };
                    _context.categoryToProducts.Add(cat);
                }
                _context.SaveChanges();
            }




            return RedirectToPage("Index");
        }
    }
}
