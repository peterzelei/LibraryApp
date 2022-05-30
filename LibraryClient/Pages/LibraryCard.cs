using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebApi_Common.Models;

namespace LibraryClient.Pages
{
    public partial class LibraryCard
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

        public IEnumerable<Book> Books { get; set; }

        public string Name { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Books = (await HttpClient.GetFromJsonAsync<Book[]>("book")).Where(b => b.NameOfBorrower == Name && b.IsBorrowed)
                                                                       .OrderBy(b => b.DateOfReturn);
            await base.OnInitializedAsync();
        }
    }
}
