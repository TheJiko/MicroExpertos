using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace UserApi.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public List<User> users = new List<User>();

        public async Task OnGetAsync()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("https://localhost:44387/api/users/");

            users = JsonConvert.DeserializeObject<List<User>>(json);
        }
    }
}
