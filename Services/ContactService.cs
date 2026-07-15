using System;
using System.Collections.Generic;
using PhoneBook.Models;
using PhoneBook.Repositories;

namespace PhoneBook.Services
{
    public class ContactService
    {
        public void EditContact(string oldNumber, string newName, string newNumber)
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine($"Error while updating contact: {ex.Message}");
            }
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
            try
            {
                repository.Add(contact);

                Console.WriteLine("Contact saved!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while saving contact: {ex.Message}");
            }
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
            try
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
            catch (Exception ex)
            {
                Console.WriteLine($"Error while deleting contact: {ex.Message}");
            }
        }
    }
}