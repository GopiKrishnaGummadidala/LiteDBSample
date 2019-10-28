using Carmax.API.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carmax.API.Data
{
    public class DbContext : IDbContext
    {
        private static string connectionString { get; set; }
        public DbContext()
        {
            connectionString = @"D:\MyContactsData.db";
        }

        public IEnumerable<Contact> GetContacts()
        {
            using (var db = new LiteDatabase(connectionString))
            {
                var collection = db.GetCollection<Contact>("Contacts");
                return collection.Find(c=>c.Id != 0);
            }
        }

        public bool AddContact(Contact contact)
        {
            using (var db = new LiteDatabase(connectionString))
            {
                var collection = db.GetCollection<Contact>("Contacts");
                var res = collection.Insert(contact);
                return true;
            }
        }

        public Contact GetContactById(int id)
        {
            using (var db = new LiteDatabase(connectionString))
            {
                var collection = db.GetCollection<Contact>("Contacts");
                return collection.FindById(id);
            }
        }

        public bool UpdateContact(Contact contact)
        {
            using (var db = new LiteDatabase(connectionString))
            {
                var collection = db.GetCollection<Contact>("Contacts");
                return collection.Update(contact);
            }
        }

        public bool DeleteContact(int id)
        {
            using (var db = new LiteDatabase(connectionString))
            {
                var collection = db.GetCollection<Contact>("Contacts");
                return collection.Delete(id);
            }
        }
    }
}
