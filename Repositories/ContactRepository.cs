using System.Collections.Generic;
using System.Linq;
using PhoneBook.Data;
using PhoneBook.Models;

namespace PhoneBook.Repositories
{
    class ContactRepository
    {
        public List<Contact> Search(string phrase)
        {
            return db.Contacts
                .Where(c => c.Name.Contains(phrase))
                .ToList();
        }
        
        private readonly PhoneBookContext db;

        public ContactRepository()
        {
            db = new PhoneBookContext();
            db.Database.EnsureCreated();
        }


        public void Add(Contact contact)
        {
            db.Contacts.Add(contact);
            db.SaveChanges();
        }


        public List<Contact> GetAll()
        {
            return db.Contacts.ToList();
        }


        public Contact? GetByNumber(string number)
        {
            return db.Contacts.FirstOrDefault(c => c.Number == number);
        }


        public void Delete(Contact contact)
        {
            db.Contacts.Remove(contact);
            db.SaveChanges();
        }


        public void Update(Contact contact)
        {
            db.Contacts.Update(contact);
            db.SaveChanges();
        }
    }
}