﻿using CarRentalVG.Common.Classes;
using CarRentalVG.Common.Enums;

namespace CarRentalVG.Common.Interfaces;

public interface IBooking
{
    int Id { get; set; }
    VehicleInherit Vehicle { get; }
    IPerson Customer { get; set; }
    int KmRented { get; set; }
    int? KmReturned { get; set; }
    DateTime PickupDate { get; }
    DateTime? ReturnDate { get; set; }
    double? TotalCost { get; }
    bool Status { get; set; }
}