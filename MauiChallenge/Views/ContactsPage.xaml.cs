using MauiChallenge.Models;
using Newtonsoft.Json;
using MauiChallenge.Helpers;

namespace MauiChallenge.Views;

public partial class ContactsPage : ContentPage
{

	private readonly HttpClient _httpClient;

	public ContactsPage()
	{
		InitializeComponent();

		_httpClient = new HttpClient();
		load_Contacts();
	}


	private async void load_Contacts()
	{
		var response = await _httpClient.GetAsync("https://randomuser.me/api/?page=1&results=100&seed=abc");
		if (response.IsSuccessStatusCode)
		{
			var json = await response.Content.ReadAsStringAsync();
			var contactResponse = JsonConvert.DeserializeObject<ContactResponseModel>(json);

			if (contactResponse != null && contactResponse.Contacts != null)
			{
				_proccessContacts(contactResponse.Contacts);
			}
			else
			{
				await DisplayAlert("Error", "No contacts found.", "OK");
			}
		}
		else
		{
			await DisplayAlert("Error", "Failed to load contacts.", "OK");
		}
	}

	private async void _proccessContacts(List<ContactModel> contacts)
	{
		BindableLayout.SetItemsSource(ContactsList, contacts);
		foreach (var contact in contacts)
		{
			if (contact.Login?.Password != null)
			{
				contact.Login.Password = PasswordHelper.Rot13Password(contact.Login.Password);
			}
			else
			{
				contact.Login.Password = "No password available";
			}
		}
	}

	private async void OnShowPasswordClicked(object sender, EventArgs e)
	{
		var button = (Button)sender;
		var password = button.CommandParameter as string;

		if (!string.IsNullOrEmpty(password))
		{
			await DisplayAlert("Password Information", $"The password is: {password}", "OK");
		}
		else
		{
			await DisplayAlert("Password Information", "No password available", "OK");
		}
	}
	
}