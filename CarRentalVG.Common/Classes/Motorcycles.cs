using CarRentalVG.Common.Enums;
using CarRentalVG.Common.Interfaces;

namespace CarRentalVG.Common.Classes;

public class Motorcycles : VehicleInherit
{
    public Motorcycles(int id, string regNo, string make, int odometer, double costKm, VehicleTypes vehicleType, double costday, VehicleStatuses vehicleStatus)
        => (RegNo, Make, Odometer, CostKm, VehicleType, CostDay, VehicleStatus)
        = (regNo, make, odometer, costKm, vehicleType, costday, vehicleStatus);
}