using System;

// ------------------ Order Class ------------------
public class Order
{
    // Private fields
    private List<Product> _products;
    private Customer _customer;

    // Constructor (each order has one customer and many products)
    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    // Add a product to the order
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    // Calculate total price = sum of product costs + shipping
    public double GetTotalPrice()
    {
        double total = 0;
        foreach (var product in _products)
        {
            total += product.GetTotalCost();
        }

        // Shipping: $5 (USA) or $35 (international)
        total += _customer.IsInUSA() ? 5 : 35;
        return total;
    }

    // Generate packing label (product name and ID)
    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var product in _products)
        {
            label += $"{product.GetName()} (ID: {product.GetProductId()})\n";
        }
        return label;
    }

    // Generate shipping label (customer name and address)
    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}";
    }
}
