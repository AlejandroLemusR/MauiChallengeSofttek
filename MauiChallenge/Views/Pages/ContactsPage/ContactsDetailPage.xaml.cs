using MauiChallenge.ViewModels.Pages;

namespace MauiChallenge.Views.Pages.ContactsPage;

public partial class ContactsDetailPage : ContentPage
{
	public ContactsDetailPage()
	{
		InitializeComponent();
        BindingContext = new ContactsDetailPageViewModel();
    }
}