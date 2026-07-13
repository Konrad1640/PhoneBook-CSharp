using System;
using System.Collections.Generic;
using System.Text.Json;
using PhoneBook.Models;

namespace PhoneBook
{
    class FileService
    {
        private string fileName = "contacts.json";


        public void Save(List<Contact> contacts)
        {
            string json = JsonSerializer.Serialize(contacts);

            File.WriteAllText(fileName, json);
        }


        public List<Contact> Load()
        {
            if (!File.Exists(fileName))
            {
                return new List<Contact>();
            }


            string json = File.ReadAllText(fileName);

            return JsonSerializer.Deserialize<List<Contact>>(json)
                ?? new List<Contact>();
        }
    }
}