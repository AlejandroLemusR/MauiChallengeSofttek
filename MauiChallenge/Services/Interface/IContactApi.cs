using MauiChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiChallenge.Services.Interface
{
    public interface IContactApi
    {
        Task<List<ContactModel>> GetContacts(int page);
    }
}
