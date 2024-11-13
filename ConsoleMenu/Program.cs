
using ConsoleMenu.Menu;
using PizzaLibrary.Data;
using PizzaLibrary.Exeptions;
using PizzaLibrary.Models;
using PizzaLibrary.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        MenuItemRepository menuRepo = new MenuItemRepository(MockData.MenuItemData);
        CustomerRepository customerRepo = new CustomerRepository(MockData.CustomerData);

        MenuItem expensivePizza = menuRepo.GetMostExpensiveItem();
        Console.WriteLine(expensivePizza);

        try
        {
            customerRepo.AddCustomer(new Customer("Egon", "1111", "AaAaa"));
            customerRepo.AddCustomer(new Customer("Kaj", "11112", "Flörb"));

            customerRepo.AddCustomer(new VIPCustomer("Aragon Son of Arathorn", "15", "Flörb", 0.25));
        }
        catch (CustomerMobileNumberExistsException CMNEEx)
        {
            Console.WriteLine($"{CMNEEx.Message}");
        }
        catch (TooHighDiscountException THDEx)
        {
            Console.WriteLine($"{THDEx.Message}");
        }


        UserMenu menu = new UserMenu();
        menu.ShowMenu();
    }
}