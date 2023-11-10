﻿using CarRentalVG.Common.Enums;
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
    public void CalcCost(DateTime returnDate, DateTime pickupDate, int kmReturned)
    {
        var rentedDays = (returnDate - pickupDate).TotalDays;
        if (rentedDays < 1) { rentedDays = 1; }

        var distance = KmReturned - KmRented;

        TotalCost = rentedDays * Vehicle.CostDay + distance * Vehicle.CostKm;
    }

    public Booking(VehicleInherit vehicle, IPerson customer)
    {
        Vehicle     = vehicle;
        Customer    = customer;
        PickupDate  = DateTime.Now;
        ReturnDate  = null;
        KmReturned  = null;
        TotalCost   = 0;
        Vehicle.VehicleStatus = VehicleStatuses.Booked;
        Status = true;
    }

    

    public Booking()
    {
        
    }
}