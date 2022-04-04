using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace UserApi.Pages.Users
{
    public class CreateModel : PageModel
    {
        private const string CONST_URL_API = "https://localhost:44387/api/users/";

        [BindProperty]
        public User user { get; set; }

        [TempData]
        public string Mensaje { get; set; }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            var httpClient = new HttpClient();
            var json = await httpClient.PostAsJsonAsync(CONST_URL_API, user);

            Mensaje = "Usuario creado correctamente";


            return RedirectToPage("Index");

        }
    }
}
