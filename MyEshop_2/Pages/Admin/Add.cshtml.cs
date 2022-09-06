using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEshop_2.Data;
using MyEshop_2.Models;

namespace MyEshop_2.Pages.Admin
{
    public class AddModel : PageModel
    {

        private MyEshopContext2 _context;

        public AddModel(MyEshopContext2 context)
        {
            _context = context;
           
        }


        [BindProperty]
        public AddOrEditProductViewModel Product { get; set; }

        [BindProperty]
        public List<int> SelectedGroups { get; set; }


        public void OnGet()
        {

            Product = new AddOrEditProductViewModel()
            {
                Categories = _context.Categories.ToList()
            };
            
        }


        public IActionResult OnPost()
        {
            ModelState.Clear();
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var Item = new Item()
            {
                price = Product.Price,
                QuantityinStock = Product.QuantityinStock,

            };
            _context.Add(Item);
            _context.SaveChanges();

            var Pro = new Product()
            {
                 Description = Product.Description,
                 Name = Product.Name,
                  ItemId = Item.id,
                   
            };

            _context.Add(Pro);

            _context.SaveChanges();







            if (Product.Picture?.Length>0)
            {
                string FilePath = Path.Combine(Directory.GetCurrentDirectory(), 
                    "wwwroot", "Images" , Pro.id + Path.GetExtension(Product.Picture.FileName));

                using(var stream = new FileStream(FilePath , FileMode.Create))
                {
                    Product.Picture.CopyTo(stream);
                }
            }

            if (SelectedGroups.Any() && SelectedGroups.Count > 0)
            {
                foreach (var item in SelectedGroups)
                {
                    var cat = new CategoryToProduct()
                    {
                        CategoryId = item,
                        ProductId = Pro.id
                    };
                    _context.categoryToProducts.Add(cat);
                }
                _context.SaveChanges();
            }





            return RedirectToPage("Index");
        }

       
    }
}
