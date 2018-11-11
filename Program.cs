using Phonebook.Enums;
using Phonebook.Models;
using System;

namespace Phonebook
{
    class Program
    {
        static void Main()
        { 
            Menu();
            MenuOption menuOption = ReadMenuOption();
            MenuWorker(menuOption);
        }

        private static MenuOption ReadMenuOption()
        {
            string input = Console.ReadLine().ToLower();
            if (!Enum.TryParse(input, out MenuOption menuOption))
            {
                menuOption = MenuOption.unknown;
            }

            return menuOption;
        }

        private static void Menu()
        {
            Console.WriteLine("MENU:");
            Console.WriteLine("'Add' to add a contact: ");
            Console.WriteLine("'View' to view the list of contacts: ");
            Console.WriteLine("'Delete' to select and delete a contact: ");
            Console.WriteLine("'Update' to select and update a contact: ");
            Console.WriteLine("'Quit' at anytime to exit: ");
            Console.WriteLine();
            Console.WriteLine("---------------------");
            Console.WriteLine("Enter action");
        }

        private static void MenuWorker(MenuOption menuOption)
        {
            ContactManager contactManager = new ContactManager();

            switch (menuOption)
            {
                case MenuOption.add:
                    contactManager.Add();
                    Continue();
                    break;
                case MenuOption.delete:
                    contactManager.PrintAll();
                    contactManager.RemoveContact();
                    Continue();
                    break;
                case MenuOption.update:
                    contactManager.UpdateUserInformation();
                    Continue();
                    break;
                case MenuOption.view:
                    contactManager.PrintAll();
                    Continue();
                    break;
                case MenuOption.quit:
                    break;
                case MenuOption.unknown:
                default:
                    Console.WriteLine();
                    Console.WriteLine("Please, read menu options and try again.");
                    Console.ReadKey(true);
                    Console.Clear();
                    Main();
                    break;
            }
        }

        private static void Continue()
        {
            Console.WriteLine("Continue: Yes/No");
            var input = Console.ReadLine().ToLower();
            if (!Enum.TryParse(input, out Answer answer))
            {
                answer = Answer.unknown;
            }
            switch (answer)
            {
                case Answer.no:
                case Answer.unknown:
                    break;
                case Answer.yes:
                default:
                    Console.Clear();
                    Main();
                    break;
            }
        }
    }
}

    

