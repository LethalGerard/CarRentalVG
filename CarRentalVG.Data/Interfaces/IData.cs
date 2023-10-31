using CarRentalVG.Common.Classes;
using CarRentalVG.Common.Enums;
using CarRentalVG.Common.Interfaces;

namespace CarRentalVG.Data.Interfaces;

public interface IData
{
    IEnumerable<IPerson> GetCustomer();
    IEnumerable<VehicleInherit> GetVehicles(VehicleStatuses status = default);
    IEnumerable<IBooking> GetBookings();
}