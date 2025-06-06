using MauiChallenge.Models;
using Newtonsoft.Json;
using MauiChallenge.Helpers;
using MauiChallenge.ViewModels.Pages;

namespace MauiChallenge.Views.Pages.ContactsPage;

public partial class ContactsPage : ContentPage
{
	public ContactsPage(ContactsPageViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}