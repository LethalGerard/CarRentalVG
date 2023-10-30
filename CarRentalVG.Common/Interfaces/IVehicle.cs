using System.Globalization;
using CarRentalVG.Common.Enums;

namespace CarRentalVG.Common.Interfaces;

public interface IVehicle
{
    string RegNo { get; }
    string Make { get; }
    int Odometer { get; set; }
    double CostKm { get; }
    VehicleTypes VehicleType { get; }
    double CostDay { get; }
    VehicleStatuses VehicleStatus { get; set; }
}