using System;
// ------------------ Customer Class ------------------
public class Customer
{
    // Private fields
    private string _name;
    private Address _address;

    // Constructor
    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    // Public getters
    public string GetName() => _name;
    public Address GetAddress() => _address;

    // Method to check if customer lives in the USA
    public bool IsInUSA()
    {
        // Delegates responsibility to Address class
        return _address.IsInUSA();
    }
}

