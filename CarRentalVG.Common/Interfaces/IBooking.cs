using CarRentalVG.Common.Enums;

namespace CarRentalVG.Common.Interfaces;

public interface IBooking
{
    IVehicle Vehicle { get; }
    IPerson Customer { get; }
    int KmRented { get; }
    int? KmReturned { get; set; }
    DateTime PickupDate { get; }
    DateTime ReturnDate { get; set; }
    double? TotalCost { get; }
    bool Status { get; set; }
}