using ConsoleMenu.Controllers.MenuItems;
using PizzaLibrary.Data;
using PizzaLibrary.Models;
using PizzaLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu.Menu
{
    public class UserMenu
    {
        private static string mainMenuChoices = "\t1.Vis Pizzamenu\n\t2.Vis Kunder\n\t3.Add Customer\n\t4.Add Pizza\n\tQ.Afslut\n\n\tIndtast valg:";

        private CustomerRepository _customerRepository = new CustomerRepository(MockData.CustomerData);
        private MenuItemRepository _menuItemRepository = new MenuItemRepository(MockData.MenuItemData);
        private static string ReadChoice(string choices)
        {
            Console.Clear();
            Console.Write(choices);
            string choice = Console.ReadLine();
            Console.Clear();
            return choice.ToLower();
        }
        public void ShowMenu()
        {
            string theChoice = ReadChoice(mainMenuChoices);
            while (theChoice != "q")
            {
                try
                {

                    switch (theChoice)
                    {
                        case "1":
                            Console.WriteLine("Valg 1");
                            ShowMenuItemController showMenuItemController = new ShowMenuItemController(_menuItemRepository);
                            showMenuItemController.ShowAllMenuItems();
                            Console.ReadLine();
                            break;
                        case "2":
                            Console.WriteLine("Valg 2");
                            _customerRepository.PrintAllCustomers();
                            Console.ReadLine();
                            break;
                        case "3":
                            Console.WriteLine("Valg 3");
                            Console.WriteLine("Indlæs navn:");
                            string name = Console.ReadLine();
                            Console.WriteLine("Indlæs mobil nr:");
                            string mobile = Console.ReadLine();
                            Console.WriteLine("Indlæs adresse:");
                            string address = Console.ReadLine();
                            Console.WriteLine("Vil du være clubmember y/n");
                            string clubMemberString = Console.ReadLine().ToLower();
                            bool isClubMember = (clubMemberString[0] == 'y') ? true : false;

                            _customerRepository.AddCustomer(new Customer(name, mobile, address));//Why not just like this? Because of null?

                            //AddCustomerController addMenuItemController = new AddCustomerController(name, mobile, address, isClubMember, _customerRepository);
                            //addMenuItemController.AddCustomer();
                            break;
                        
                        case "4":
                            Console.WriteLine("Valg 4");
                            Console.WriteLine("Indlæs navnet på produktet:");
                            string itemName = Console.ReadLine();
                            Console.WriteLine("Fastslå en pris:");

                            double price;
                            if (double.TryParse(Console.ReadLine(), out double result))
                            {
                                price = result;
                            }
                            else throw new ArgumentException();

                            Console.WriteLine("Beskriv produktet:");
                            string description = Console.ReadLine();

                            Console.WriteLine("Angiv hvilke af følgende typer produktet passer i");

                            List<MenuType> availibleTypes = Enum.GetValues(typeof(MenuType)).Cast<MenuType>().ToList();
                            for(int i = 0; i < availibleTypes.Count; i++)
                            {
                                Console.WriteLine(i + ". "+availibleTypes[i]);
                            }
                            string choice = Console.ReadLine();
                            if(int.TryParse(choice, out int choiceInt) && choiceInt > 0 && choiceInt <= availibleTypes.Count)
                            {
                                MenuItem refForDisplay = new MenuItem(itemName, price, description, availibleTypes[choiceInt]);
                                _menuItemRepository.AddMenuItem(refForDisplay);
                                Console.WriteLine($"The following product were added:\n{refForDisplay.ToString()}\n click any button to continue");
                                Console.ReadLine();
                            } else
                            {
                                throw new ArgumentException();
                            }

                        
                            break;
                        
                        default:
                            Console.WriteLine("Angiv et tal fra 1..4 eller q for afslut");
                            break;
                    }
                }
                catch (ArgumentException argEx)
                {
                    Console.WriteLine(argEx.Message);
                    Console.ReadLine();
                }
                theChoice = ReadChoice(mainMenuChoices);
            }
        }

    }

}
