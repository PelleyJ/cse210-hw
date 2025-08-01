public class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public string GetName() => _name;

    public string GetShippingAddress() => _address.GetFullAddress();

    public bool IsInUSA() => _address.IsInUSA();
}
