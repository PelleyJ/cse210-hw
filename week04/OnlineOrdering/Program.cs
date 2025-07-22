using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create address and customer 1 (USA)
        Address address1 = new Address("123 Elm St", "Boise", "ID", "USA");
        Customer customer1 = new Customer("John Smith", address1);

        // Create products for order 1
        Product product1 = new Product("USB Flash Drive", "UFD001", 9.99m, 3);
        Product product2 = new Product("Wireless Mouse", "WM123", 25.50m, 1);

        // Create order 1
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        // Create address and customer 2 (International)
        Address address2 = new Address("456 Maple Ave", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Emma Chen", address2);

        // Create products for order 2
        Product product3 = new Product("Bluetooth Speaker", "BTS456", 45.75m, 2);
        Product product4 = new Product("Power Bank", "PB789", 29.99m, 1);
        Product product5 = new Product("USB-C Cable", "USBC321", 7.95m, 2);

        // Create order 2
        Order order2 = new Order(customer2);
        order2.AddProduct(product3);
        order2.AddProduct(product4);
        order2.AddProduct(product5);

        // Display details for each order
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

// =========================
// Product Class
// =========================
class Product
{
    private string _name;
    private string _productId;
    private decimal _price;
    private int _quantity;

    public Product(string name, string productId, decimal price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    public decimal GetTotalCost()
    {
        return _price * _quantity;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetProductId()
    {
        return _productId;
    }
}

// =========================
// Address Class
// =========================
class Address
{
    private string _street;
    private string _city;
    private string _stateProvince;
    private string _country;

    public Address(string street, string city, string stateProvince, string country)
    {
        _street = street;
        _city = city;
        _stateProvince = stateProvince;
        _country = country;
    }

    public bool IsInUSA()
    {
        return _country.Trim().ToUpper() == "USA";
    }

    public string GetFullAddress()
    {
        return $"{_street}\n{_city}, {_stateProvince}\n{_country}";
    }
}

// =========================
// Customer Class
// =========================
class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetShippingAddress()
    {
        return _address.GetFullAddress();
    }

    public bool IsInUSA()
    {
        return _address.IsInUSA();
    }
}

// =========================
// Order Class
// =========================
class Order
{
    private Customer _customer;
    private List<Product> _products;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public decimal GetTotalPrice()
    {
        decimal productTotal = 0;
        foreach (Product product in _products)
        {
            productTotal += product.GetTotalCost();
        }

        decimal shipping = _customer.IsInUSA() ? 5.00m : 35.00m;
        return productTotal + shipping;
    }

    public string GetPackingLabel()
    {
        string label = "";
        foreach (Product product in _products)
        {
            label += $"{product.GetName()} (ID: {product.GetProductId()})\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"{_customer.GetName()}\n{_customer.GetShippingAddress()}";
    }
}
