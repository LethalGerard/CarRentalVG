using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalVG.Common.Interfaces;

public interface IPerson
{
    int Id { get; set; }
    int Ssn { get; }
    string FirstName { get; }
    string LastName { get; }
}