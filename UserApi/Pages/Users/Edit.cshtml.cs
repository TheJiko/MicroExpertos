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
    public class EditModel : PageModel
    {
        private const string CONST_URL_API = "https://localhost:44387/api/users/";

        [BindProperty]
        public User user { get; set; }

        [TempData]
        public string Mensaje { get; set; }

        public async Task OnGet(int id)
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("https://localhost:44387/api/users/" + id);

            user = JsonConvert.DeserializeObject<User>(json);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var httpClient = new HttpClient();
                var json = await httpClient.PutAsJsonAsync(CONST_URL_API + user.Id, user);

                Mensaje = "Usuario editado correctamente";
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
