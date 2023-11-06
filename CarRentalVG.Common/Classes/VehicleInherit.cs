using CarRentalVG.Common.Enums;

namespace CarRentalVG.Common.Classes;

public class VehicleInherit
{
    public int Id { get; set; }
    public string RegNo { get; set; }
    public string Make { get; set; }
    public int Odometer { get; set; }
    public double CostKm { get; set; }
    public VehicleTypes VehicleType { get; set; }
    public double CostDay { get; set; }
    public VehicleStatuses VehicleStatus { get; set; }

    public VehicleInherit(string regNo, string make, int odometer, double costKm, VehicleTypes vehicleType, double costday, VehicleStatuses vehicleStatus)
    => (RegNo, Make, Odometer, CostKm, VehicleType, CostDay, VehicleStatus)
    = (regNo, make, odometer, costKm, vehicleType, costday, vehicleStatus);

    }

