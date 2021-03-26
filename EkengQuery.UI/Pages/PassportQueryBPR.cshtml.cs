using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EkengQuery.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EkengQuery.UI.Pages
{
    public class PassportQueryBPRModel : PageModel
    {
        private readonly IBPRQuery _iBPRQuery;

        public PassportQueryBPRModel(IBPRQuery iBPRQuery)
        {
            _iBPRQuery = iBPRQuery;
            Citizen = new PassportWebServiceResponse();
        }


        [BindProperty]
        public string Passport { get; set; }

        [BindProperty]
        public PassportWebServiceResponse Citizen { get; set; }


        public void OnGet()
        {
            Passport = string.Empty;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!String.IsNullOrEmpty(Passport))
            {
                Citizen = await _iBPRQuery.GetCitizenByPassport(Passport);
            }
            return Page();
        }
    }
}
