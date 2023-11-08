using CarRentalVG.Common.Enums;
using CarRentalVG.Common.Interfaces;
namespace CarRentalVG.Common.Classes;

public class Car : VehicleInherit
{
    public Car(int id, string regNo, string make, int odometer, double costKm, VehicleTypes vehicleType, double costDay, VehicleStatuses vehicleStatus)
        : base(id, regNo, make, odometer, costKm, vehicleType, costDay, vehicleStatus)
    {}
    // public void Car() { }
}