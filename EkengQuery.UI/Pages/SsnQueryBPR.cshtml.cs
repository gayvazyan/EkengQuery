using System;
using System.Threading.Tasks;
using EkengQuery.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EkengQuery.UI.Pages
{
    public class SsnQueryBPRModel : PageModel
    {
        private readonly IBPRQuery _iBPRQuery;
        public SsnQueryBPRModel(IBPRQuery iBPRQuery)
        {
            _iBPRQuery = iBPRQuery;
            Citizen = new SSNWebServiceResponse();
        }

        [BindProperty]
        public string Ssn { get; set; }

        [BindProperty]
        public string ImageSource { get; set; }

        [BindProperty]
        public SSNWebServiceResponse Citizen { get; set; }
        public void OnGet()
        {
            Ssn = string.Empty;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!String.IsNullOrEmpty(Ssn))
            {
                Citizen = await _iBPRQuery.GetCitizenBySSN(Ssn);
                byte[] data = Convert.FromBase64String(Citizen.Photo);
                ImageSource = string.Format("data:image/png;base64,{0}", Convert.ToBase64String(data));
            }
            return Page();
        }
    }
}
