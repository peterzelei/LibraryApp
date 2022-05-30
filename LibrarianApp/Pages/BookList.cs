﻿using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using WebApi_Common.Models;
using Microsoft.AspNetCore.Components.Web;

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

        private async Task  UpdateRentalStatus(long BookID,Book Book)
        {
            Book.IsBorrowed = false;
            Book.DateOfReturn = System.DateTime.MinValue;
            Book.DateOfBorrowing = System.DateTime.MinValue;
            Book.NameOfBorrower = "";
            await HttpClient.PutAsJsonAsync($"book/{BookID}", Book);
        }
    }
}
