using System;

// ------------------ Program (Main) ------------------
public class Program
{
    public static void Main(string[] args)
    {
        // ----------- Order 1: USA Customer -----------
        Address addr1 = new Address("123 Main St", "Springfield", "IL", "USA");
        Customer cust1 = new Customer("John Doe", addr1);
        Order order1 = new Order(cust1);
        order1.AddProduct(new Product("Laptop", "L123", 999.99, 1));
        order1.AddProduct(new Product("Mouse", "M456", 25.50, 2));

        // ----------- Order 2: International Customer -----------
        Address addr2 = new Address("1 street", "San Pedro Sula", "Cortes", "Honduras");
        Customer cust2 = new Customer("Carlos Perez", addr2);
        Order order2 = new Order(cust2);
        order2.AddProduct(new Product("Phone", "P789", 799.99, 1));
        order2.AddProduct(new Product("Charger", "C101", 19.99, 3));
        order2.AddProduct(new Product("Headphones", "H202", 59.99, 2));

        // ----------- Display Results -----------
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalPrice():0.00}\n");

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalPrice():0.00}\n");
    }
}
