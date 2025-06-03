using System;

class Program
{
    static void Main(string[] args)
    {
        // Order 1 - USA Customer
        Address address1 = new Address("123 Main St", "Springfield", "IL", "USA");
        Customer customer1 = new Customer("John Doe", address1);
        Order order1 = new Order(customer1);

        order1.AddProduct(new Product("Notebook", "A123", 3.5, 5));
        order1.AddProduct(new Product("Pen", "B456", 1.2, 10));

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost():F2}\n");

        // Order 2 - International Customer
        Address address2 = new Address("456 Maple Ave", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Jane Smith", address2);
        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("Book", "C789", 10.0, 2));
        order2.AddProduct(new Product("Backpack", "D321", 25.0, 1));

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.GetTotalCost():F2}");
    }
}
