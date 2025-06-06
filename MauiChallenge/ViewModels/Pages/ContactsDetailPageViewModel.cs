using CommunityToolkit.Mvvm.ComponentModel;
using MauiChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiChallenge.ViewModels.Pages
{
    public partial class ContactsDetailPageViewModel : BaseViewModel, IQueryAttributable
    {
        private ContactModel _contact;
        public ContactModel Contact
        {
            get => _contact;
            set
            {
                _contact = value;
                OnPropertyChanged("Contact");
            }
        }

        public ICommand GoBackCommand { get; }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.TryGetValue("contact", out var contactObj) && contactObj is ContactModel contactModel)
            {
                Contact = contactModel;
            }
        }

        public ContactsDetailPageViewModel() 
        {
            GoBackCommand = new Command(
                async () =>
                    await Shell.Current.GoToAsync("//ContactPage")
                );
        }
    }
}
