using CarRentalVG.Common.Enums;
using CarRentalVG.Common.Interfaces;

namespace CarRentalVG.Data.Interfaces;

public interface IData
{
    IEnumerable<IPerson> GetCustomer();
    IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default);
    IEnumerable<IBooking> GetBookings();
}