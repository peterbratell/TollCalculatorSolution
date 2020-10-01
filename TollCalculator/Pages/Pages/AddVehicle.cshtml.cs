using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TollCalculator.Models;

namespace TollCalculator.Pages.Pages
{
    public class AddVehicleModel : PageModel
    {
        [BindProperty]
        public AddVehicleModel VehicleToAdd { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            return RedirectToPage("/Index");
            //return RedirectToPage("/Index", new { FirstName = VehicleToAdd.Name });
        }
    }
}
