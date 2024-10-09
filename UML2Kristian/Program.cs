// See https://aka.ms/new-console-template for more information
using PizzaLibrary.Models;
using PizzaLibrary.Services;

Customer c1 = new Customer("Karl Franz","THE EMPIRE CALLS","Altdorf");
Console.WriteLine(c1.ToString());

CustomerRepository testCustomerRepo = new CustomerRepository();
testCustomerRepo.AddCustomer(c1);
testCustomerRepo.printAllCustomers();

Console.WriteLine(c1.ToString());