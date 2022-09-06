using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyEshop_2.Data;
using MyEshop_2.Models;

namespace MyEshop_2.Pages.Admin.ManageUser
{
    public class CreateModel : PageModel
    {
        private readonly MyEshop_2.Data.MyEshopContext2 _context;

        public CreateModel(MyEshop_2.Data.MyEshopContext2 context)
        {
            _context = context;
        }
        [BindProperty]
        public Users Users { get; set; } = default!;


        public IActionResult OnGet()
        {
           
            return Page();
        }

        



        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid || _context.Users == null || Users == null)
            //  {
            //      return Page();
            //  }

            //ModelState.Remove("Id");


            ModelState.Clear();


            if (!ModelState.IsValid)
            {
                return Page();
            }





            _context.Users.Add(Users);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
