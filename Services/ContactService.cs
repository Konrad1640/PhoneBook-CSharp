using System;
using System.Collections.Generic;
using System.Linq;
using PhoneBook.Data;
using PhoneBook.Models;

namespace PhoneBook.Services
{
    class ContactService
    {
        private readonly PhoneBookContext db;


        public ContactService()
        {
            db = new PhoneBookContext();
            db.Database.EnsureCreated();
        }


        public void AddContact(Contact contact)
        {
            db.Contacts.Add(contact);

            db.SaveChanges();

            Console.WriteLine("Contact saved!");
        }
    }
}