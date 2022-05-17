﻿using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebApi_Common.Models;
using System;

namespace LibrarianApp.Pages
{
    public partial class BookAdd : ComponentBase
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public Book Book { get; set; } = new Book();

        private async Task SubmitForm()
        {
            Book.IsBorrowed = false;
            Book.NameOfBorrower = "";
            Book.DateOfBorrowing = new DateTime();
            Book.DateOfReturn = new DateTime();

            await HttpClient.PostAsJsonAsync("book", Book);
            NavigationManager.NavigateTo("books");
        }
    }
}
