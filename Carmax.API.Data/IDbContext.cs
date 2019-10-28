using Carmax.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
