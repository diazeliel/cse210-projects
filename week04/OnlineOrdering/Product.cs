using System;
// ------------------ Product Class ------------------
public class Product
{
    // Private fields (encapsulation: variables cannot be accessed directly)
    private string _name;
    private string _productId;
    private double _pricePerUnit;
    private int _quantity;

    // Constructor to initialize the product
    public Product(string name, string productId, double pricePerUnit, int quantity)
    {
        _name = name;
        _productId = productId;
        _pricePerUnit = pricePerUnit;
        _quantity = quantity;
    }

    // Public getters (allow controlled access to private fields)
    public string GetName() => _name;
    public string GetProductId() => _productId;
    public double GetPricePerUnit() => _pricePerUnit;
    public int GetQuantity() => _quantity;

    // Method to calculate total cost (price per unit * quantity)
    public double GetTotalCost()
    {
        return _pricePerUnit * _quantity;
    }
}
