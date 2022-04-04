using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace UserApi.Pages.Users
{
    public class IndexModel : PageModel
    {
        private const string CONST_URL_API = "https://localhost:44387/api/users/";
        
        [BindProperty]
        public List<User> users { get; set; }

        [TempData]
        public string Mensaje { get; set; }

        public async Task OnGetAsync()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(CONST_URL_API);

            users = JsonConvert.DeserializeObject<List<User>>(json);
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var httpClient = new HttpClient();
            var user = await httpClient.GetStringAsync(CONST_URL_API + id);

            if (user == null)
            {
                return NotFound();
            }

            await httpClient.DeleteAsync(CONST_URL_API + id);

            Mensaje = "Usuario borrado correctamente";

            return RedirectToPage("Index");

        }
    }
}
