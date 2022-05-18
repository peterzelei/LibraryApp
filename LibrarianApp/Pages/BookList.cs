using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using WebApi_Common.Models;

namespace LibrarianApp.Pages
{
    public partial class BookList : ComponentBase
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

        public Book[] Books { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Books = await HttpClient.GetFromJsonAsync<Book[]>("book");
            await base.OnInitializedAsync();
        }
    }
}
