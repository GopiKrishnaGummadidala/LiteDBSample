using Carmax.API.Models;
using System.Collections.Generic;

namespace Carmax.API.Data
{
    public interface IDbContext
    {
        IEnumerable<Contact> GetContacts();
        bool AddContact(Contact contact);
        Contact GetContactById(int id);
        bool UpdateContact(Contact contact);
        bool DeleteContact(int id);
    }
}
