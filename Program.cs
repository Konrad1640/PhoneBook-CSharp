using System;
using PhoneBook.Models;
using PhoneBook.Data;
using PhoneBook.Services;
using PhoneBook.Validators;
namespace PhoneBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello from the PhoneBook app");

            var phoneBook = new PhoneBook();
            var contactService = new ContactService();

            var fileService = new FileService();

            phoneBook.Contacts = fileService.Load();

            using(var db = new PhoneBookContext())
            {
                db.Database.EnsureCreated();
            }


            while (true)
            {
                DisplayMenu();

                var userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddContact(contactService);
                        break;

                    case "2":
                        DisplayContact(phoneBook);
                        break;

                    case "3":
                        contactService.DisplayAllContacts();
                        break;

                    case "4":
                        SearchContacts(contactService);
                        break;
                    case "5":
                        EditContact(contactService);
                        break;

                    case "6":
                        DeleteContact(contactService);
                        break;

                    case "x":
                    case "X":
                        fileService.Save(phoneBook.Contacts);

                        Console.WriteLine("Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid operation");
                        break;
                }

                Console.WriteLine();
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
        }


        private static void DisplayMenu()
        {
            Console.WriteLine("===== PHONE BOOK =====");
            Console.WriteLine("1. Add contact");
            Console.WriteLine("2. Display contact by number");
            Console.WriteLine("3. Display all contacts");
            Console.WriteLine("4. Search contacts");
            Console.WriteLine("5. Edit contact");
            Console.WriteLine("6. Delete contact");
            Console.WriteLine("x. Exit");
            Console.Write("Choose option: ");
        }
       private static void DeleteContact(ContactService contactService)
        {
            Console.Write("Enter contact number to delete: ");

            var number = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(number))
            {
                Console.WriteLine("Number cannot be empty!");
                return;
            }

            contactService.DeleteContact(number);
        }

        private static void AddContact(ContactService contactService)
        {
            Console.Write("Insert number: ");
            var number = Console.ReadLine();

            Console.Write("Insert name: ");
            var name = Console.ReadLine();


          if (!ContactValidator.IsValidName(name))
            {
                Console.WriteLine("Invalid name!");
                return;
            }

            if (!ContactValidator.IsValidPhoneNumber(number))
            {
                Console.WriteLine("Invalid phone number!");
                return;
            }

            var contact = new Contact(name!, number!);

            contactService.AddContact(contact);

            Console.WriteLine("Contact added successfully!");
        }


       private static void DisplayContact(PhoneBook phoneBook)
        {
            Console.Write("Insert number: ");

            var number = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(number))
            {
                Console.WriteLine("Number cannot be empty!");
                return;
            }

            phoneBook.DisplayContact(number);
        }


        private static void SearchContacts(ContactService contactService)
        {
            Console.Write("Insert search phrase: ");

            var searchPhrase = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(searchPhrase))
            {
                Console.WriteLine("Search phrase cannot be empty!");
                return;
            }

            contactService.SearchContacts(searchPhrase);
        }
        private static void EditContact(ContactService contactService)
        {
            Console.Write("Enter current phone number: ");
            var oldNumber = Console.ReadLine();

            Console.Write("Enter new name: ");
            var newName = Console.ReadLine();

            Console.Write("Enter new number: ");
            var newNumber = Console.ReadLine();


            if (string.IsNullOrWhiteSpace(oldNumber) ||
                string.IsNullOrWhiteSpace(newName) ||
                string.IsNullOrWhiteSpace(newNumber))
            {
                Console.WriteLine("Data cannot be empty!");
                return;
            }
            if (!ContactValidator.IsValidName(newName))
            {
                Console.WriteLine("Invalid name!");
                return;
            }

            if (!ContactValidator.IsValidPhoneNumber(newNumber))
            {
                Console.WriteLine("Invalid phone number!");
                return;
            }
            contactService.EditContact(oldNumber, newName, newNumber);
        }
    }
}