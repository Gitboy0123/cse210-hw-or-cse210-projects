using System;
using System.Collections.Generic;

class Address
{
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }

    public bool IsUSAddress()
    {
        return Country == "USA";
    }

    public string GetAddressDetails()
    {
        return $"{Street}, {City}, {State}, {Country}";
    }
}

class Customer
{
    public string Name { get; set; }
    public Address Address { get; set; }

    public bool IsUSCustomer()
    {
        return Address.IsUSAddress();
    }
}

class Product
{
    public string Name { get; set; }
    public int ProductId { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }

    public double GetTotalPrice()
    {
        return Price * Quantity;
    }
}

class Order
{
    private Customer customer;
    private List<Product> products = new List<Product>();

    public Order(Customer customer)
    {
        this.customer = customer;
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public double GetTotalCost()
    {
        double total = 0.0;
        foreach (var product in products)
        {
            total += product.GetTotalPrice();
        }
        total += (customer.IsUSCustomer() ? 5.0 : 35.0);
        return total;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var product in products)
        {
            label += $"Product: {product.Name}, Product ID: {product.ProductId}\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\nCustomer Name: {customer.Name}\nCustomer Address: {customer.Address.GetAddressDetails()}";
    }
}

class Program
{
    static void Main()
    {
        Address address1 = new Address
        {
            Street = "123 Main St",
            City = "Cityville",
            State = "CA",
            Country = "USA"
        };

        Customer customer1 = new Customer
        {
            Name = "John Doe",
            Address = address1
        };

        Address address2 = new Address
        {
            Street = "456 Elm St",
            City = "Townsville",
            State = "ON",
            Country = "Canada"
        };

        Customer customer2 = new Customer
        {
            Name = "Alice Smith",
            Address = address2
        };

        Product product1 = new Product
        {
            Name = "Laptop",
            ProductId = 101,
            Price = 899.99,
            Quantity = 2
        };

        Product product2 = new Product
        {
            Name = "Smartphone",
            ProductId = 102,
            Price = 499.99,
            Quantity = 1
        };

        Product product3 = new Product
        {
            Name = "Tablet",
            ProductId = 103,
            Price = 299.99,
            Quantity = 3
        };

        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product3);

        Console.WriteLine($"Order 1 Total Cost: ${order1.GetTotalCost()}");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());

        Console.WriteLine($"Order 2 Total Cost: ${order2.GetTotalCost()}");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
    }
}