using System;
using System.Collections.Generic;
using System.IO;

namespace Phonebook.Models
{
    class FileManager
    {
        private readonly string FilePath = @"C:\Phonebook.txt";

        public FileManager()
        {
            if (!File.Exists(FilePath))
            {
                File.AppendAllLines(FilePath, new[] { "" });
            }           
        }

        public bool AddContactToFile(Contact contact)
        {
            bool isSuccessful = false;
            try
            {
                using (StreamWriter sw = new StreamWriter(FilePath, true))
                {
                    sw.WriteLine(contact.Firstname + "," + contact.Lastname + "," + contact.PhoneNumber + "," + contact.PersonalNumber + ",");
                    isSuccessful = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong" + ex);
            }
            return isSuccessful;
        }

        public List<Contact> ReadFromFile() //ContactManager contactManager
        {
            string textLine;
            var contacts = new List<Contact>();
            try
            {
                using (StreamReader streamReader = new StreamReader(FilePath))
                {
                    while ((textLine = streamReader.ReadLine()) != null)
                    {
                        if (!string.IsNullOrEmpty(textLine))
                        {
                            string[] contactInfo = textLine.Split(',');
                            Contact contact = new Contact
                            {
                                Firstname = contactInfo[0],
                                Lastname = contactInfo[1],
                                PhoneNumber = contactInfo[2],
                                PersonalNumber = contactInfo[3]
                            };
                            //contactManager.ContactList.Add(contact);
                            contacts.Add(contact);
                        }
                       
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File does not exist.");
            }
            return contacts;
        }

        public bool UpdateContactOnFile(List<Contact> contactList)
        {
            bool isSuccessful = false;
            try
            {
                using (StreamWriter sw = new StreamWriter(FilePath))
                {
                    foreach (var contact in contactList)
                    {
                        sw.WriteLine(contact.Firstname + "," + contact.Lastname + "," + contact.PhoneNumber + "," + contact.PhoneNumber + ",");
                    }
                    isSuccessful = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong" + ex);
            }
            return isSuccessful;
        }

        //public void Update(string firstName, string lastName)
        //{
        //    //string[] arr = File.ReadAllLines(FilePath);
        //    //var writer = new StreamWriter(FilePath);

        //    //for (int i = 0; i < arr.Length; i++)
        //    //{
        //    //    string line = arr[i];
        //    //    line.Replace("match", "new value");
        //    //    writer.WriteLine(line);
        //    //}
        //    List<Contact> contacts = ReadFromFile();
        //}

    }
}
