using LibrarySystem.Domain.Models;

namespace LibrarySystem.Domain.UserAggregate.ValueObjects;

public class Address : ValueObject
{
    private Address() { }

    private Address(string country, string city, string street, int postalCode)
    {
        Country = country;
        City = city;
        Street = street;
        PostalCode = postalCode;
    }

    public string Country { get; }
    public string City { get; }
    public string Street { get; }
    public int PostalCode { get; }

    public static Address CreateAddress(string country, string city, string street, int postalCode)
    {
        return new Address(country, city, street, postalCode);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Country;
        yield return City;
        yield return Street;
        yield return PostalCode;
    }
}
