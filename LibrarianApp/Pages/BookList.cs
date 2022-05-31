using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using WebApi_Common.Models;
using Microsoft.AspNetCore.Components.Web;
using System.Collections.Generic;
using System.Linq;

namespace LibrarianApp.Pages
{
    public partial class BookList : ComponentBase
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

        public Book[] Books { get; set; }

        public string SearchText = "";

        IEnumerable<Book> FilteredBooks => 
            Books.Where(b => b.Title.ToLower().Contains(SearchText.ToLower()) || b.Author.ToLower().Contains(SearchText.ToLower()));

        protected override async Task OnInitializedAsync()
        {
            Books = await HttpClient.GetFromJsonAsync<Book[]>("book");
            await base.OnInitializedAsync();
        }

        private async Task UpdateRentalStatus(long BookID, Book Book)
        {
            Book.Initialize();
            await HttpClient.PutAsJsonAsync($"book/{BookID}", Book);
        }
    }
}
