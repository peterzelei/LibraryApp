using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebApi_Common.Models;

namespace ClientApp.Pages
{
    public partial class BookList
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
