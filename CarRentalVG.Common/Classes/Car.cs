﻿using CarRentalVG.Common.Enums;
using CarRentalVG.Common.Interfaces;
namespace CarRentalVG.Common.Classes;

public class Car : VehicleInherit
{
    public int Id { get; set; }
    public string RegNo { get; set; }
    public string Make { get; set; }
    public int Odometer { get; set; }
    public double CostKm { get; set; }
    public VehicleTypes VehicleType { get; set; }
    public double CostDay { get; set; }
    public VehicleStatuses VehicleStatus { get; set; }

    public Car(int id, string regNo, string make, int odometer, double costKm, VehicleTypes vehicleType, double costDay, VehicleStatuses vehicleStatus)
        => (Id, RegNo, Make, Odometer, CostKm, VehicleType, CostDay, VehicleStatus)
        = (id, regNo, make, odometer, costKm, vehicleType, costDay, vehicleStatus);
}