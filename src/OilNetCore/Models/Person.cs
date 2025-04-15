using Microsoft.Graph.Models;

namespace OilNetCore.Models;

public class Person : EntityBase
{
    public Person()
    {
        
    }
    
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    
}

public class Address : EntityBase
{
    public Address()
    {
        
    }

    public AddressType Type { get; set; } = AddressType.Unknown;
    public string Street { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
}

public class Phone : EntityBase
{
    public Phone()
    {
        
    }

    public PhoneType Type { get; set; } = PhoneType.Other;
    public string Number { get; set; } = string.Empty;
}

public class Email : EntityBase
{
    public Email()
    {
        
    }

    public string Address { get; set; } = string.Empty;
}