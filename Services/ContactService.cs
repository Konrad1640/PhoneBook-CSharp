using System;
using System.Collections.Generic;
using PhoneBook.Models;
using PhoneBook.Repositories;

namespace PhoneBook.Services
{
    class ContactService
    {
        public void EditContact(string oldNumber, string newName, string newNumber)
        {
            var contact = repository.GetByNumber(oldNumber);

            if(contact == null)
            {
                Console.WriteLine("Contact not found");
                return;
            }

            contact.Name = newName;
            contact.Number = newNumber;

            repository.Update(contact);

            Console.WriteLine("Contact updated successfully!");
        }
        
        private readonly ContactRepository repository;

        public void SearchContacts(string phrase)
        {
            var contacts = repository.Search(phrase);

            foreach(var contact in contacts)
            {
                Console.WriteLine($"Contact: {contact.Name}, {contact.Number}");
            }
        }
        public ContactService()
        {
            repository = new ContactRepository();
        }


        public void AddContact(Contact contact)
        {
            repository.Add(contact);

            Console.WriteLine("Contact saved!");
        }


        public List<Contact> GetContacts()
        {
            return repository.GetAll();
        }

        public void DisplayAllContacts()
        {
            var contacts = repository.GetAll();

            foreach(var contact in contacts)
            {
                Console.WriteLine($"Contact: {contact.Name}, {contact.Number}");
            }
        }

        public void DeleteContact(string number)
        {
            var contact = repository.GetByNumber(number);

            if(contact == null)
            {
                Console.WriteLine("Contact not found");
                return;
            }

            repository.Delete(contact);

            Console.WriteLine("Contact deleted!");
        }
    }
}