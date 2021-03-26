using EkengQuery.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EkengQuery.UI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ISearchService _searchService;

        public IndexModel(ISearchService searchService)
        {
            _searchService = searchService;
            Input = new InputModel();
        }

        [BindProperty]
        public InputModel Input { get; set; }

        [BindProperty]
        public List<ApplicantModel> ResultList { get; set; }


        public class InputModel
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Passport { get; set; }

        }

        public void OnGet()
        {

        }
        public void OnPost()
        {
            var firstName = Input.FirstName;
            var lastName = Input.LastName;
            var passport = Input.Passport;

            if (passport == null)
            {
                ResultList = _searchService.GetResultWithOutPassport(firstName, lastName);
            }
            else
            {
                ResultList = _searchService.GetResultWithPassport(firstName, lastName, passport);
            }

        }
    }
}
