using System;

namespace PhoneBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello from the PhoneBook app");

            var phoneBook = new PhoneBook();

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
                        AddContact(phoneBook);
                        break;

                    case "2":
                        DisplayContact(phoneBook);
                        break;

                    case "3":
                        phoneBook.DisplayAllContacts();
                        break;

                    case "4":
                        SearchContacts(phoneBook);
                        break;
                    case "5":
                        EditContact(phoneBook);
                        break;

                    case "6":
                        DeleteContact(phoneBook);
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

        private static void DeleteContact(PhoneBook phoneBook)
        {
            Console.Write("Enter contact number to delete: ");

            var number = Console.ReadLine();

            phoneBook.DeleteContact(number);
        }


        private static void AddContact(PhoneBook phoneBook)
        {
            Console.Write("Insert number: ");
            var number = Console.ReadLine();

            Console.Write("Insert name: ");
            var name = Console.ReadLine();


            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(number))
            {
                Console.WriteLine("Name and number cannot be empty!");
                return;
            }


            var contact = new Contact(name, number);

            phoneBook.AddContact(contact);

            Console.WriteLine("Contact added successfully!");
        }


        private static void DisplayContact(PhoneBook phoneBook)
        {
            Console.Write("Insert number: ");

            var number = Console.ReadLine();

            phoneBook.DisplayContact(number);
        }


        private static void SearchContacts(PhoneBook phoneBook)
        {
            Console.Write("Insert search phrase: ");

            var searchPhrase = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(searchPhrase))
            {
                Console.WriteLine("Search phrase cannot be empty!");
                return;
            }

            phoneBook.DisplayMatchingContacts(searchPhrase);
        }
        private static void EditContact(PhoneBook phoneBook)
        {
            Console.Write("Enter current phone number: ");
            var oldNumber = Console.ReadLine();

            Console.Write("Enter new name: ");
            var newName = Console.ReadLine();

            Console.Write("Enter new number: ");
            var newNumber = Console.ReadLine();


            phoneBook.EditContact(oldNumber, newName, newNumber);
        }
    }
}