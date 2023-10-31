using CarRentalVG.Common.Interfaces;

namespace CarRentalVG.Common.Classes;

public class Customer : IPerson
{
    public int Id { get; set; }
    public int Ssn { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Customer(int id, int ssn, string firstName, string lastName)
        => (Ssn, FirstName, LastName)
         = (ssn, firstName, lastName);

    public Customer()
    {

    }
}