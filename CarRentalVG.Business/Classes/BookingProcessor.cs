using CarRentalVG.Common.Classes;
using CarRentalVG.Common.Enums;
using CarRentalVG.Common.Interfaces;
using CarRentalVG.Data.Interfaces;

namespace CarRentalVG.Business.Classes;

public class BookingProcessor
{
    private readonly IData _db;
    public BookingProcessor(IData db) => _db = db;

    public IEnumerable<IPerson> GetCustomer() { return _db.GetCustomer(); }
    public IEnumerable<VehicleInherit> GetVehicles(VehicleStatuses status = default) { return _db.GetVehicles(status); }
    public IEnumerable<IBooking> GetBookings() { return _db.GetBookings(); }
}