using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace PhoneBook
{
    class PhoneBook
    {
        private PhoneBookContext db;
        public List<Contact> Contacts { get; set; } = new List<Contact>();
        public PhoneBook()
        {
            db = new PhoneBookContext();

            db.Database.EnsureCreated();
        }
        

        public void AddContact(Contact contact)
        {
            Console.WriteLine($"Before save: {db.Contacts.Count()} contacts in database");

            db.Contacts.Add(contact);

            db.SaveChanges();

            Console.WriteLine($"After save: {db.Contacts.Count()} contacts in database");

            Console.WriteLine("Saved to database!");
        }

        public void DeleteContact(string number)
        {
            var contact = db.Contacts
                .FirstOrDefault(c => c.Number == number);


            if(contact == null)
            {
                Console.WriteLine("Contact not found");
                return;
            }


            db.Contacts.Remove(contact);

            db.SaveChanges();


            Console.WriteLine("Contact deleted successfully!");
        }

        private void DisplayContactDetails(Contact contact)
        {
            Console.WriteLine($"Contact: {contact.Name}, {contact.Number}");
        }

        public void DisplayContact(string number)
    {
        var contact = db.Contacts
            .FirstOrDefault(c => c.Number == number);


        if(contact == null)
        {
            Console.WriteLine("Contact not found");
            return;
        }


        DisplayContactDetails(contact);
    }

        
                private void DisplayContactsDetails(List<Contact> contacts)
        {
             foreach (var contact in contacts)
            {
                DisplayContactDetails(contact);
            }
        }
        public void DisplayContacts(string number)
        {
            var contact = Contacts.FirstOrDefault(c => c.Number == number);
            
            if  (contact == null)
            {
               Console.WriteLine("Contact not found"); 
            }
            else
            {
                DisplayContactDetails(contact);
            }
        }
        public void DisplayAllContacts()
        {
            var contacts = db.Contacts.ToList();

            DisplayContactsDetails(contacts);
        }
        public void DisplayMatchingContacts(string searchPhrase)
        {
            var matchingContacts = db.Contacts
                .Where(c => c.Name.Contains(searchPhrase))
                .ToList();

            if(matchingContacts.Count == 0)
            {
                Console.WriteLine("No contacts found");
                return;
            }

            DisplayContactsDetails(matchingContacts);
        }
       public void EditContact(string oldNumber, string newName, string newNumber)
        {
            var contact = db.Contacts
                .FirstOrDefault(c => c.Number == oldNumber);


            if(contact == null)
            {
                Console.WriteLine("Contact not found");
                return;
            }


            contact.Name = newName;
            contact.Number = newNumber;


            db.SaveChanges();


            Console.WriteLine("Contact updated successfully!");
        }
    }
}