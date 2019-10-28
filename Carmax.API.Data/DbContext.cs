using Carmax.API.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Carmax.API.Data
{
    public class DbContext : IDbContext
    {
        private static string connectionString { get; set; }
        public DbContext()
        {
            connectionString = ConfigurationManager.AppSettings["DbPath"];
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
            try
            {
                using (var db = new LiteDatabase(connectionString))
                {
                    var collection = db.GetCollection<Contact>("Contacts");
                    collection.Insert(contact);
                    return true;
                }
            }
            catch(Exception ex)
            {
                //Exception Logging
                return false;
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
            try
            {
                using (var db = new LiteDatabase(connectionString))
                {
                    var collection = db.GetCollection<Contact>("Contacts");
                    return collection.Update(contact);
                }
            }
            catch (Exception ex)
            {
                //Exception Logging
                return false;
            }
        }

        public bool DeleteContact(int id)
        {
            try
            {
                using (var db = new LiteDatabase(connectionString))
                {
                    var collection = db.GetCollection<Contact>("Contacts");
                    return collection.Delete(id);
                }
            }
            catch (Exception ex)
            {
                //Exception Logging
                return false;
            }
        }
    }
}
