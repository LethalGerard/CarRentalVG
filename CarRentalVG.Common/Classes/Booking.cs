using CarRentalVG.Common.Enums;
using CarRentalVG.Common.Interfaces;

namespace CarRentalVG.Common.Classes;

public class Booking : IBooking
{
    public int Id { get; set; }
    public VehicleInherit Vehicle { get; set; }
    public IPerson Customer { get; set; }
    public int KmRented { get; set; }
    public int? KmReturned { get; set; }
    public DateTime PickupDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public double? TotalCost { get; set; }
    public bool Status { get; set; }



    //räkna ut cost

    public Booking(VehicleInherit vehicle, IPerson customer)
    {
        Vehicle     = vehicle;
        Customer    = customer;
        PickupDate  = DateTime.Now;
        ReturnDate  = null;
        KmRented = vehicle.Odometer;
        KmReturned  = null;
        TotalCost   = 0;
        Vehicle.VehicleStatus = VehicleStatuses.Booked;
        Status = true;
    }

    

    public Booking()
    {
        
    }
}