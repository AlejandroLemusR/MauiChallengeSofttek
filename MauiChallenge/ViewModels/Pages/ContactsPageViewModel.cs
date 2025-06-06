using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiChallenge.Models;
using MauiChallenge.Services;
using MauiChallenge.Services.Interface;
using MauiChallenge.Views.Pages.ContactsPage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiChallenge.ViewModels.Pages
{
    public partial class ContactsPageViewModel : BaseViewModel
    {
        private readonly IContactApi _contactApi;
        private int pageNumber = 1;

        public ObservableCollection<ContactModel> ContactsList { get; } = new();
        public ICommand ShowPasswordCommand { get; }
        public ICommand LoadMoreContactsCommand { get; }
        public ICommand ContactSelectedCommand { get; }

        private bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set { _isLoading = value; OnPropertyChanged("IsLoading"); }
        }

        public ContactsPageViewModel(IContactApi contactApi)
        {
            _contactApi = contactApi;
            LoadMoreContactsCommand = new Command(LoadMoreContacts);
            ShowPasswordCommand = new Command<string>(ShowPassword);
            ContactSelectedCommand = new Command<ContactModel>(ContactSelected);
            GetContactsApi();
        }

        private async void GetContactsApi()
        {
            try
            {
                if (IsLoading) return;

                //IsLoading = true;

                var contacts = await _contactApi.GetContacts(pageNumber);
                foreach (ContactModel contact in contacts)
                {
                    ContactsList.Add(contact);
                }
                await Task.Delay(1000); // Simulate delay
                IsLoading = false;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error API", ex.Message, "OK");
            }
        }

        private async void ShowPassword(string password)
        {
            if (!string.IsNullOrEmpty(password))
            {
                await Application.Current.MainPage.DisplayAlert("Password Information", $"The password is: {password}", "OK");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Password Information", "No password available", "OK");
            }
        }

        private async void LoadMoreContacts()
        {
            pageNumber = pageNumber + 1;
            GetContactsApi();
        }

        private async void ContactSelected(ContactModel contact)
        {
            if (contact != null)
            {
                var navigationParameter = new ShellNavigationQueryParameters
                {
                    {"contact", contact }
                };
                await Shell.Current.GoToAsync("//ContactsDetailPage", true, new Dictionary<string, object>
{
    { "contact", contact }
});
            }
        }
    }
}
