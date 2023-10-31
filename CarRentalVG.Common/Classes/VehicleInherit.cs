using CarRentalVG.Common.Enums;

namespace CarRentalVG.Common.Classes;

public class VehicleInherit
{
    public int Id { get; set; }
    public string RegNo { get; }
    public string Make { get; }
    public int Odometer { get; set; }
    public double CostKm { get; }
    public VehicleTypes VehicleType { get; }
    public double CostDay { get; set; }
    public VehicleStatuses VehicleStatus { get; set; }
}
