using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Elm St", "Boise", "ID", "USA");
        Customer customer1 = new Customer("John Smith", address1);
        Product product1 = new Product("USB Flash Drive", "UFD001", 9.99m, 3);
        Product product2 = new Product("Wireless Mouse", "WM123", 25.50m, 1);
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Address address2 = new Address("456 Maple Ave", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Emma Chen", address2);
        Product product3 = new Product("Bluetooth Speaker", "BTS456", 45.75m, 2);
        Product product4 = new Product("Power Bank", "PB789", 29.99m, 1);
        Product product5 = new Product("USB-C Cable", "USBC321", 7.95m, 2);
        Order order2 = new Order(customer2);
        order2.AddProduct(product3);
        order2.AddProduct(product4);
        order2.AddProduct(product5);

        DisplayOrder(order1);
        Console.WriteLine(new string('-', 40));
        DisplayOrder(order2);
    }

    static void DisplayOrder(Order order)
    {
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order.GetTotalPrice():0.00}");
    }
}
