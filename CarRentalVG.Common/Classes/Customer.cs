using CarRentalVG.Common.Interfaces;

namespace CarRentalVG.Common.Classes;

public class Customer : IPerson
{
    public int Ssn { get; }
    public string FirstName { get; }
    public string LastName { get; }

    public Customer(int ssn, string firstName, string lastName)
        => (Ssn, FirstName, LastName)
         = (ssn, firstName, lastName);
}