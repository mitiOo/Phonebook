using System;
using System.Collections.Generic;
using System.Linq;

namespace Phonebook.Models
{
    public class ContactManager
    {
        private readonly FileManager file;
        private List<Contact> contacts { get; set; }

        public ContactManager()
        {
            file = new FileManager();
            contacts = file.ReadFromFile(); //new List<Contact>();
        }

        public void Add()
        {
            Console.WriteLine("Enter firstName:");
            var firstName = Console.ReadLine();
            Console.WriteLine("Enter lastName:");
            var lastName = Console.ReadLine();
            Console.WriteLine("Enter phone number:");
            var phoneNumber = Console.ReadLine();
            Console.WriteLine("Enter personal number:");
            var personalNumber = Console.ReadLine();

            Contact contact = new Contact
            {
                Firstname = firstName,
                Lastname = lastName,
                PhoneNumber = phoneNumber,
                PersonalNumber = personalNumber
            };

            contacts.Add(contact);

            bool success = file.AddContactToFile(contact);
            if (success)
            {
                Console.WriteLine("Contact is saved.");
            }           
        }
        
        public void RemoveContact()
        {
            if (!contacts.Any())
            {
                Console.WriteLine("There is no contacts to delete.");
            }
            else
            {
                Console.WriteLine("Enter firstName of the contact you want to remove");
                var firstName = Console.ReadLine();
                Console.WriteLine("Enter lastname of the contact you want to remove");
                var lastName = Console.ReadLine();

                contacts.RemoveAll(c => c.Firstname == firstName && c.Lastname == lastName);
                bool isSuccessful = file.UpdateContactOnFile(contacts);

                if (isSuccessful)
                {
                    Console.WriteLine("Contact is deleted");
                }
           }          
        }

        public void PrintAll()
        {
            var list = file.ReadFromFile();

            if (list != null && list.Any())
            {
                foreach (Contact contact in file.ReadFromFile())
                {
                    Console.WriteLine($"FirstName: {contact.Firstname}, LastName: {contact.Lastname}, Phone: {contact.PhoneNumber}, EGN: {contact.PersonalNumber}");
                }
            }
            else
            {
                Console.WriteLine("Contact list is empty.");
            }           
        }

        public void UpdateUserInformation()
        {
            Console.WriteLine("Enter firstname on existing contact to be updated");
            var oldFirstName = Console.ReadLine();

            var contactToUpdate = contacts.Where(c => c.Firstname == oldFirstName).ToList();

            if (contactToUpdate.Any())
            {
                Console.WriteLine("Enter a new first Name");
                var newFirstName = Console.ReadLine();
                Console.WriteLine("Enter a new last Name");
                var newLastName = Console.ReadLine();
                Console.WriteLine("Enter a new phone number");
                var newPhone = Console.ReadLine();
                Console.WriteLine("Enter a new personal number");
                var newPersonalNumber = Console.ReadLine();

                UpdateContactList(contactToUpdate, newFirstName, newLastName, newPhone, newPersonalNumber);
            }
            else
            {
                Console.WriteLine("Contact is not found.");
            }          
        }

        private void UpdateContactList(List<Contact> contactToUpdate, string newFirstName, string newLastName, string newPhone, string newPersonalNumber)
        {
            var updatedContacts = contacts.Except(contactToUpdate).ToList();

            contactToUpdate.ForEach(c2u => { c2u.Firstname = newFirstName; c2u.Lastname = newLastName; c2u.PhoneNumber = newPhone; c2u.PersonalNumber = newPersonalNumber; });

            updatedContacts.AddRange(contactToUpdate);

            if (file.UpdateContactOnFile(updatedContacts))
                Console.WriteLine("Contact is successfuly updated.");
        }

        //private void UpdateUserFunction(string userOption, string oldFirstName)
        //{
        //    var contactToUpdate = ContactList.Where(c => c.Firstname == oldFirstName);
        //    string newValue;

        //    if (userOption == "1")
        //    {
        //        Console.WriteLine("Enter a new first Name");
        //        newValue = Console.ReadLine();

        //        foreach (var person in contactToUpdate)
        //        {
        //            person.FirstName = newValue;
        //            wtf.UpdateUserOnFile(adressBookList);
        //        }
        //    }
        //    else if (userOption == "2")
        //    {
        //        Console.WriteLine("Enter a new last name");
        //        newValue = Console.ReadLine();

        //        foreach (var person in contactToUpdate)
        //        {
        //            person.LastName = newValue;
        //            wtf.UpdateUserOnFile(adressBookList);
        //        }
        //    }
        //    else if (userOption == "3")
        //    {
        //        Console.WriteLine("Enter a new adress");
        //        newValue = Console.ReadLine();

        //        foreach (var person in contactToUpdate)
        //        {
        //            person.Adress = newValue;
        //            wtf.UpdateUserOnFile(adressBookList);
        //        }
        //    }
        //}
    }
}
